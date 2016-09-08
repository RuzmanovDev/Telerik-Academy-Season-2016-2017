function solve() {
    Array.prototype.contains = function (v) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === v) return true;
        }
        return false;
    };

    Array.prototype.unique = function () {
        var arr = [];
        for (var i = 0; i < this.length; i++) {
            if (!arr.contains(this[i])) {
                arr.push(this[i]);
            }
        }
        return arr;
    };

    var validator = {
        validateIfEmpty: function (value) {
            value = value || "Value";
            if (value.length === 0) {
                throw new Error(value + " cannot be empty!")
            }
        },
        validateIfString: function (value) {
            if (!value || typeof value !== "string") {
                value = value || "value";
                throw new Error(value + " must be string")
            }
        },
        validateIfInRange: function (min, max, value) {
            value = value || value;
            if (value.length < min || value.length > max) {
                throw new Error(value + "length must be between " + min + " and " + max);
            }
        },
        validateIsbn: function (value) {
            if (value.length !== 10 && value.length !== 13) {
                throw new Error('ISBN must be either 10 or 13 digits');
            }

            if (!/^[0-9]+$/.test(value.toString())) {
                throw new Error('ISBN must be a valid number');
            }
        },
        validateIfNumber: function (value) {
            if ((!value && value !== 0) || typeof value !== 'number') {
                throw new Error(" Value  must be a number")
            }
        },
        validateIfNumIsInrange: function (value, min, max) {
            min = min || 0;
            max = max || 9223372036854775808;
            if (value < min || value > max) {
                value = value || "value";
                throw new Error(value + "must be between " + min + " and " + max);
            }

        },
        validateIsItemLike: function (element) {
            if (!element.hasOwnProperty("name") || !element.hasOwnProperty("description")) {
                throw new Error("The item must be item-like")
            }
        }
    };

    var item = (function () {
        var item,
            itemId = 0;


        item = Object.create({}, {
            id: {
                get: function () {
                    return this._id;
                }
            },
            name: {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateIfString(value);
                    validator.validateIfInRange(2, 40, value);
                    this._name = value;
                }
            },
            description: {
                get: function () {
                    return this._description;
                },
                set: function (value) {
                    validator.validateIfString(value);
                    validator.validateIfEmpty(value);
                    this._description = value;
                }
            }
        });

        Object.defineProperty(item, "init", {
            value: function (name, description) {
                this._id = ++itemId;
                this.name = name;
                this.description = description;

                return this;
            }
        });
        return item;
    }());

    var book = (function (parent) {
        var book = Object.create(parent);
        Object.defineProperty(book, "init", {
            value: function (name, description, isbn, genre) {
                parent.init.call(this, name, description);
                this.isbn = isbn;
                this.genre = genre;

                return this;
            }
        });
        Object.defineProperty(book, "isbn", {
            get: function () {
                return this._isbn;
            },
            set: function (value) {
                validator.validateIsbn(value);
                this._isbn = value;
            }
        });
        Object.defineProperty(book, "genre", {
            get: function () {
                return this._genre;
            },
            set: function (value) {
                validator.validateIfString(value);
                validator.validateIfInRange(2, 20, value);
                this._genre = value;
            }
        });

        return book;
    }(item));

    var media = (function (parent) {
        var media = Object.create(parent);

        Object.defineProperty(media, "init", {
            value: function (name, description, duration, rating) {
                parent.init.call(this, name, description);
                this.duration = duration;
                this.rating = rating;
                return this;
            }
        });

        Object.defineProperty(media, "rating", {
            get: function () {
                return this._rating;
            },
            set: function (value) {
                value = +value;
                validator.validateIfNumber(value);
                validator.validateIfNumIsInrange(value, 1, 5);
                this._rating = value;
            }
        });

        Object.defineProperty(media, "duration", {
            get: function () {
                return this._duration;
            },
            set: function (value) {
                validator.validateIfNumber(value);
                validator.validateIfNumIsInrange(value, 1, Infinity);

                this._duration = value;
            }
        });

        return media;
    }(item));

    var catalog = (function () {
        function validateArgs(args) {
            if (args === undefined || args.length === 0) {
                throw new Error("Args cannot be undefined");
            }

            args.forEach(function (element) {
                if (!element instanceof item) {
                    throw new Error("The items in the catalog must be instance of item class");
                }
                validator.validateIsItemLike(element);
            });
        }

        var catalog = Object.create({}),
            catId = 0;

        Object.defineProperty(catalog, "init", {
            value: function (name) {
                this._id = ++catId;
                this.name = name;
                this.items = [];
                return this;
            }
        });

        Object.defineProperty(catalog, "id", {
            get: function () {
                return this._id;
            }
        });

        Object.defineProperty(catalog, "name", {
            get: function () {
                return this._name;
            },
            set: function (value) {
                validator.validateIfString(value);
                validator.validateIfInRange(2, 40, value);

                this._name = value;
            }
        });

        Object.defineProperty(catalog, "add", {
            value: function () {
                var that = this;
                var args = arguments.slice() || [];
                validateArgs(args);
                args.map(function (element) {
                    that.items.push(element);
                });

                return this;
            }
        });

        Object.defineProperty(catalog, "find", {
            value: function (params) {
                if (typeof params === "object") {
                    return this.items.filter(function (item) {
                        return Object.keys(params)
                            .every(function (key) {
                                return item[key] === params[key];
                            })
                    });
                } else {
                    validator.validateIfNumber(params);
                    var foundItems = this.items.find(function (element) {
                        return element.id === params;
                    });

                    return foundItems || null;
                }
            }
        });

        Object.defineProperty(catalog, "search", {
            value: function (pattern) {
                validator.validateIfString(pattern);
                validator.validateIfInRange(1, Infinity, pattern);

                pattern = pattern.toLowerCase();
                var foundelements = [];
                this.items.forEach(function (element) {
                    if (element.description.toLowerCase().indexOf(pattern) >= 0
                        || element.name.toLowerCase().indexOf(pattern) >= 0) {
                        foundelements.push(element);
                    }
                });
                return foundelements;
            }
        });
        return catalog;
    }());

    var bookCatalog = (function (parent) {
        var bookCatalog = Object.create(parent);

        Object.defineProperty(bookCatalog, "init", {
            value: function (name) {
                parent.init.call(this, name);

                return this;
            }
        });

        Object.defineProperty(bookCatalog, "add", {
            value: function (params) {
                if (typeof params === 'function') {
                    throw new Error("Add works only with arrays or comma seperated values");
                }
                params = params.slice();
                params.forEach(function (element) {
                    if (typeof element !== "book" && typeof element !== "function") {
                        throw new Error("Value to add must be a book");
                    }
                });

                parent.add.apply(this, params);
                return this;
            }
        });

        Object.defineProperty(bookCatalog, "getGenres", {
            value: function () {
                var allGenres = [];
                this.items.map(function (element) {
                    allGenres.push(element.genre.toLowerCase());
                });

                return allGenres.unique();
            }
        });

        return bookCatalog;
    }(catalog));
    var mediaCatalog = (function (parent) {
        var mediaCatalog = Object.create(parent)

        // TODO: add methods not working properly
        Object.defineProperty(mediaCatalog, 'add', {
            value: function (params) {
                params = params.slice();
                params.forEach(function (element) {
                    if (typeof element !== "media" && typeof element !== "function") {
                        throw new Error("Value to add must be a book");
                    }
                });

                parent.add.apply(this, arguments);
                return this;
            }
        });

        Object.defineProperty(mediaCatalog, 'getTop', {
            value: function (count) {
                count = +count;
                if (!count || count < 1) {
                    throw Error();
                }

                return this.items.sort(function (a, b) {
                    return b.rating - a.rating;
                })
                    .slice(0, count)
                    .map(function (item) {
                        return {
                            id: item.id,
                            name: item.name
                        }
                    });
            }
        });
        Object.defineProperty(mediaCatalog, 'getSortedByDuration', {
            value: function () {
                return this.items.sort(function (a, b) {
                    if (a.duration !== b.duration) {
                        return a.duration - b.duration;
                    } else {
                        return b.id - a.id;
                    }
                }).slice(0);
            }
        });
        Object.defineProperty(mediaCatalog, "init", {
            value: function (name) {
                parent.init.call(this, name);
                return this;
            }
        });

        return mediaCatalog;
    }(catalog));
    return {
        getBook: function (name, isbn, genre, description) {
            return Object.create(book).init(name, description, isbn, genre);
        },
        getMedia: function (name, rating, duration, description) {
            return Object.create(media).init(name, description, duration, rating);
        },
        getBookCatalog: function (name) {
            return Object.create(bookCatalog).init(name);
        },
        getMediaCatalog: function (name) {
            return Object.create(mediaCatalog).init(name);
        }
    };
}
 module.exports = solve;
// var module = solve();
// var catalog = module.getBookCatalog('John\'s catalog');
// //
// var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
// console.log(book1);
// var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
//
// var media = module.getMedia(222,1,222,5);
// console.log(media);
// console.log(book1);
//
// console.log(book2);
// // catalog.add(book1);
// // catalog.add(book2);
// //
// // console.log(catalog.find(book1.id));
// // //returns book1
// //
// // console.log(catalog.find({id: book2.id, genre: 'IT'}));
// // //returns book2
// //
// // console.log(catalog.search('js'));
// // // returns book2
// //
// // console.log(catalog.search('javascript'));
// // //returns book1 and book2
// //
// // console.log(catalog.search('Te sa zeleni'));
// // //returns []
