/* use 'eversion: 6' */

function solve() {
    if (!Object.keys) {
        Object.keys = (function () {
            'use strict';
            var hasOwnProperty = Object.prototype.hasOwnProperty,
                hasDontEnumBug = !({toString: null}).propertyIsEnumerable('toString'),
                dontEnums = [
                    'toString',
                    'toLocaleString',
                    'valueOf',
                    'hasOwnProperty',
                    'isPrototypeOf',
                    'propertyIsEnumerable',
                    'constructor'
                ],
                dontEnumsLength = dontEnums.length;

            return function (obj) {
                if (typeof obj !== 'object' && (typeof obj !== 'function' || obj === null)) {
                    throw new TypeError('Object.keys called on non-object');
                }

                var result = [], prop, i;

                for (prop in obj) {
                    if (hasOwnProperty.call(obj, prop)) {
                        result.push(prop);
                    }
                }

                if (hasDontEnumBug) {
                    for (i = 0; i < dontEnumsLength; i++) {
                        if (hasOwnProperty.call(obj, dontEnums[i])) {
                            result.push(dontEnums[i]);
                        }
                    }
                }
                return result;
            };
        }());
    }
    if (!Array.prototype.includes) {
        Array.prototype.includes = function (searchElement /*, fromIndex*/) {
            'use strict';
            if (this == null) {
                throw new TypeError('Array.prototype.includes called on null or undefined');
            }

            var O = Object(this);
            var len = parseInt(O.length, 10) || 0;
            if (len === 0) {
                return false;
            }
            var n = parseInt(arguments[1], 10) || 0;
            var k;
            if (n >= 0) {
                k = n;
            } else {
                k = len + n;
                if (k < 0) {
                    k = 0;
                }
            }
            var currentElement;
            while (k < len) {
                currentElement = O[k];
                if (searchElement === currentElement ||
                    (searchElement !== searchElement && currentElement !== currentElement)) { // NaN !== NaN
                    return true;
                }
                k++;
            }
            return false;
        };
    }

    var Item, Book, Catalog, BookCatalog, MediaCatalog, Validator, Media,
        NameIdMixin;

    Validator = function () {
        Validator = {
            validateIfUndefinedOrNull(value){
                if (value === null || typeof value === "undefined" || !value) {
                    throw  new Error("The value is null or undefined!");
                }
            },
            validateStringLengthInRange(name, min, max){
                if (typeof  name === "undefined") {
                    throw new Error("Please provide a name");
                }

                if (name.length < min || name.length > max) {
                    throw new Error("The name must be between 2 and 40 chars long!")
                }
            },
            nonEmptyStringValidator(name){
                // if (typeof  name === "undefined") {
                //     throw new Error("Please provide a name");
                // }

                if (!name || name.length === 0) {
                    throw  new Error("The string must NOT be empty!");
                }
            },
            isbnValidator(isbn){
                isbn = "" + isbn;
                if (isbn.length === 10 || isbn.length === 13) {
                    if (!isbn.match(/\d+/)) {
                        throw  new Error("The isbn must contain Only digits!");
                    }
                } else {
                    throw  new Error("The isbn must contain only 10 or 13 DIGITS")
                }
            },
            validateIfNumber(value){
                if (typeof(value) === "undefined") {
                    throw  new Error("The value cannot be undefined!");
                }

                if (typeof (+value) !== "number") {
                    throw  new Error("the value must be a number");
                }
            },
            validateNumberRange(number, min, max){
                min = min || 0;
                max = max || 9999999999;
                if (number < min || number > max) {
                    throw  new Error(`The number must be between ${min} and ${max}`);
                }
            }
        };

        return Validator;
    }();
    var validate = {
        isString: function (value, msg) {
            msg = msg || ' non-existent or not a string';
            if (!value || typeof value !== 'string') {
                throw Error(value + msg);
            }
        },
        isNumber: function (value, msg) {
            msg = msg || ' non-existent or not a number';
            if ((!value && value !== 0) || typeof value !== 'number') {
                throw Error(value + msg);
            }
        },
        isItem: function (value) {
            return Object.keys(Item)
                .every(function (key) {
                    return (typeof value[key] !== 'undefined');
                });
        },
        isBook: function (value) {
            var isBook = this.isItem(value) && Object.keys(Book)
                    .every(function (key) {
                        return (typeof value[key] !== 'undefined');
                    });
            return isBook;
        },
        isMedia: function (value) {
            var isMedia = this.isItem(value) && Object.keys(Media)
                    .every(function (key) {
                        return (typeof value[key] !== 'undefined');
                    });
            return isMedia;
        },
        stringLength: function (value, min, max, msg) {
            msg = msg || 'Invalid string length';
            this.isString(value);
            if (value.length < min || value.length > max) {
                throw Error(msg);
            }
        },
        ISBN: function (value, msg) {
            msg = msg || 'Invalid ISBN length';
            //value = value.replace(/-/g, '');
            this.isString(value);
            if (value.length !== 10 && value.length !== 13) {
                throw Error(msg);
            }
        },
        numberRange: function (value, min, max, msg) {
            msg = msg || ' not in range';
            this.isNumber(value);

            if (value < min || value > max) {
                throw Error(value + msg + '[' + min + '..' + max + ']');
            }
        }
    };
    NameIdMixin = (function () {
        let id = 0;
        let NameidMixin = Base => class extends Base {
            constructor(name) {
                super();
                this.name = name;
                this._id = (id += 1);
            }

            get id() {
                return this._id;
            }

            get name() {
                return this._name;
            }

            set name(value) {
                Validator.validateStringLengthInRange(value, 2, 40);
                this._name = value;
            }
        };

        return NameidMixin;
    }());

    Item = (function () {
        var id = 0;
        class Item extends NameIdMixin(Object) {
            constructor(name, description) {
                super(name);
                this.description = description;
            }

            get description() {
                return this._description;
            }

            set description(value) {
                Validator.nonEmptyStringValidator(value);
                this._description = value;
            }
        }

        return Item;
    }());

    Book = (function () {
        class Book extends Item {
            constructor(name, description, isbn, genre) {
                super(name, description);
                this.isbn = isbn;
                this.genre = genre;
            };

            get isbn() {
                return this._isbn;
            }

            set isbn(value) {
                Validator.isbnValidator(value);
                this._isbn = value;
            }

            get genre() {
                return this._genre;
            }

            set genre(value) {
                Validator.validateStringLengthInRange(value, 2, 20);
                this._genre = value;
            }
        }

        return Book;
    }());

    Media = (function () {
        class Media extends Item {
            constructor(name, description, duration, rating) {
                super(name, description);
                this.duration = duration;
                this.rating = rating
            }

            get duration() {
                return this._duration;
            }

            set duration(value) {
                Validator.validateIfUndefinedOrNull(value);
                Validator.validateIfNumber(value);
                Validator.validateNumberRange(value, 0);
                this._duration = value;
            }

            get rating() {
                return this._rating;
            }

            set rating(value) {
                Validator.validateIfNumber(value);
                Validator.validateNumberRange(value, 1, 5);
                this._rating = value;
            }

        }

        return Media
    }());

    Catalog = (function () {
        class Catalog extends NameIdMixin(Object) {
            constructor(name) {
                super(name);
                this.items = [];
            };

            add(items) {
                var i, len;
                if (!arguments || !items) {
                    throw Error('must pass parameters or array');
                }

                var current,
                    arr = arguments[0];
                if (!Array.isArray(arr)) {
                    arr = arguments;
                }
                for (i = 0, len = arr.length; i < len; i += 1) {
                    current = arr[i];
                    this.items.push(current);
                }
                return this;
            }

            find(params) {
                if (typeof params === 'object') {
                    return this.items.filter(function (item) {
                        return Object.keys(params)
                            .every(function (key) {
                                return item[key] === params[key];
                            })
                    });
                } else {
                    validate.isNumber(params);
                    var foundItem = this.items.find(function (item) {
                        return item.id === params;
                    });
                    return foundItem || null;
                }
            }

            search(pattern) {
                // var foundItems = [];
                // if (!pattern || pattern.length < 1) {
                //     throw  new Error("the pattern is invalid");
                // }
                //
                // this.items.forEach(function (element) {
                //     if (element.name.indexOf(pattern) >= 0 || element.description.indexOf(pattern) >= 0) {
                //         foundItems.push(element);
                //     }
                // });
                //
                // return foundItems;
                if (!pattern) {
                    throw Error('search patternt is not defined');
                }

                return this.items.filter(function (item) {
                    return item.name.indexOf(pattern) >= 0 ||
                        item.description.indexOf(pattern) >= 0;
                });
            }
        }


        return Catalog
    }());

    BookCatalog = (function () {
        class BookCatalog extends Catalog {
            constructor(name) {
                super(name);
                //this.items = [];
            }

            add() {

                var i, arr = arguments;

                if (arguments[0] && arguments[0].length) {
                    arr = arguments[0];
                }
                for (i in arr) {
                    if (typeof arr[i] !== 'function' && !validate.isBook(arr[i])) {
                        throw Error('cannot add non-book item');
                    }
                }

                super.add(arguments);
                return this;
            }

            getGenres() {
                var uniqueGenres = [];

                this.items.forEach(function (element) {
                    if (!uniqueGenres.includes(element.genre)) {
                        uniqueGenres.push(element.genre);
                    }
                });

                return uniqueGenres;
            }

        }
        return BookCatalog;
    }());

    MediaCatalog = (function () {
        class MediaCatalog extends Catalog {
            constructor(name) {
                super(name);
            }

            add() {
                var i, arr = arguments;

                if (arguments[0] && arguments[0].length) {
                    arr = arguments[0];
                }

                for (i in arr) {
                    if (typeof arr[i] !== 'function' && !validate.isMedia(arr[i])) {
                        throw Error('cannot add non-media item');
                    }
                }

                super.add(arguments);
                return this;
            }

            getTop(count) {
                count = +count;
                if (!count || count < 1) {
                    throw Error();
                }
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

            getSortedByDuration() {
                return this.items.sort(function (el1, el2) {
                    if (el1.duration !== el2.duration) {
                        return el1.duration - el2.duration;
                    } else {
                        return el2.id - el1.id;
                    }
                }).slice(0);
            }
        }

        return MediaCatalog;
    }());
    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, description, isbn, genre);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, description, duration, rating);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    };

}
// module.exports = solve;
var module = solve();

var catalog = module.getBookCatalog("Mizerii");
var book = module.getBook("Kak da pravish mizerii", 1111111111, "mizeriq-janr", "tova e kniga koqto ti kazva kak da pravish mizerii!!");
var book2 = module.getBook("Kak da pravish mizerii1", 1111111111, "mizeriq-janr", "tova e kniga koqto ti kazva kak da pravish mizerii!!");
var book3 = module.getBook("Kak da pravish mizerii2", 1111111111, "mizeriq-janr", "tova e kniga koqto ti kazva kak da pravish mizerii!!");
var s = catalog.add(book);
console.log(catalog.items);

console.log(catalog.items[0]);
console.log(book);
console.log(catalog.items[0] === book);
console.log(s === catalog);

