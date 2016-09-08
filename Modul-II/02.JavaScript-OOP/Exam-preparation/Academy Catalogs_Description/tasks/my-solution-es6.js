function solve() {
    var Item, Validator, Book, Media, Catalog, BookCatalog, MediaCatalog;

    Validator = {
        validateString(value, min, max) {
            min = min || 0;
            max = max || 9999999;
            if (typeof value !== "string") {
                throw new Error(`${value} must be a string`);
            }

            if (value.length < min || value.length > max) {
                throw new Error(`${value} must be between ${min} and ${max}`);
            }
        },
        validateIsbn(isbn) {
            isbn = "" + isbn;
            if (isbn.length === 10 || isbn.length === 13) {
                if (!isbn.match(/\d+/)) {
                    throw new Error("The isbn must contain Only digits!");
                }
            } else {
                throw new Error("The isbn must contain only 10 or 13 DIGITS")
            }
        },
        validateIfNumber(value) {
            this.validateIfNullOrUndefined(value);
            value = +value;
            if (isNaN(value)) {
                throw new Error(`${value} must be a number`)
            }
        },
        validateNumberInRange(value, min, max) {
            min = min || 0;
            max = max || 999999;
            this.validateIfNumber(value);
            if (value < min || value > max) {
                throw new Error(`${value} must be between ${min} ${max}`);
            }
        },
        validateIfItsItem(item) {
            if (!item.id || !item.name || !item.description) {
                throw new Error(`THe ${item} is not item like object!`);
            }
        },
        validateIfNullOrUndefined(value) {
            if (value === null || typeof (value) === "undefined") {
                throw new Error(`${value} is null or undefined!`);
            }
        }

    };

    Item = (function () {
        var uniqueId = 0;

        class Item {
            constructor(name, description) {
                this._id = (uniqueId += 1);
                this.name = name;
                this.description = description;
            }

            get id() {
                return this._id;
            }

            get name() {
                return this._name;
            }

            set name(value) {
                Validator.validateString(value, 2, 40);
                this._name = value;
            }

            get description() {
                return this._description;
            }

            set description(value) {
                if (!value) {
                    throw Error(`${value} must be non empty string!`);
                }
                this._description = value;
            }

        }

        return Item;
    } ());

    Book = (function () {
        class Book extends Item {
            constructor(name, description, isbn, genre) {
                super(name, description);
                this.isbn = isbn;
                this.genre = genre;
            }

            get isbn() {
                return this._isbn;
            }

            set isbn(value) {
                Validator.validateIsbn(value);
                this._isbn = value;
            }

            get genre() {
                return this._genre;
            }

            set genre(value) {
                Validator.validateString(value, 2, 20);
                this._genre = value;
            }
        }

        return Book;
    } ());

    Media = (function () {
        class Media extends Item {
            constructor(name, description, duration, rating) {
                super(name, description);
                this.duration = duration;
                this.rating = rating;
            }

            get duration() {
                return this._duration;
            }

            set duration(value) {
                Validator.validateIfNumber(value);
                Validator.validateNumberInRange(value, 1);
                this._duration = value;
            }

            get rating() {
                return this._rating;
            }

            set rating(value) {
                Validator.validateIfNumber(value);
                Validator.validateNumberInRange(value, 1, 5);

                this._rating = value;
            }

        }

        return Media;
    } ());

    Catalog = (function () {
        var uniqueId = 0;
        class Catalog {
            constructor(name) {
                this._id = (uniqueId += 1);
                this.name = name;
                this.items = [];
            }

            get id() {
                return this._id;
            }

            get name() {
                return this._name;
            }

            set name(value) {
                Validator.validateString(value, 2, 40);
                this._name = value;
            }

            add(...args) {
                if (Array.isArray(args[0])) {
                    args = args[0];
                }

                if (args.length === 0) {
                    throw new Error("The items for adding does have length of 0!");
                }

                this.items.push(...args);

                return this;
            }

            find(args) {
                Validator.validateIfNullOrUndefined(args);
                if (typeof (args) === "number") {
                    for (let item of this.items) {
                        if (item.id === args) {
                            return item;
                        }
                    }

                    return null;
                    
                } else if (typeof (args) === "object") {
                    return this.items.filter(function (element) {
                        return Object.keys(args).every(function (prop) {
                            return args[prop] === element[prop];
                        });
                    });
                } else {
                    throw new Error("Invalid type of parameters passed!");
                }
            }

            search(pattern) {
                Validator.validateString(pattern, 1);
                pattern = pattern.toLowerCase();

                var result = [];

                for (var item of this.items) {
                    if (item.name.toLowerCase().indexOf(pattern) >= 0
                        || item.description.toLowerCase().indexOf(pattern) >= 0) {
                        result.push(item);
                    }
                }

                return result;
            }
        }

        return Catalog;
    } ());

    BookCatalog = (function () {
        class BookCatalog extends Catalog {
            constructor(name) {
                super(name);
            }

            add(...books) {
                if (!books) {
                    throw new Error("asdsa");
                }

                if (Array.isArray(books[0])) {
                    books = books[0];
                }

                books.forEach(function (x) {
                    if (!(x instanceof Book)) {
                        throw new Error("Must add only books");
                    }
                });

                return super.add(...books);
            }

            getGenres() {
                var genres = {};
                this.items.forEach(function (element) {
                    genres[element.genre] = 1;
                });

                return Object.keys(genres);
            }
        }

        return BookCatalog;
    } ());

    MediaCatalog = (function () {
        class MediaCatalog extends Catalog {
            constructor(name) {
                super(name);
            }

            add(...media) {
                if (!media) {
                    throw new Error("asdsa");
                }

                if (Array.isArray(media[0])) {
                    media = media[0];
                }

                media.forEach(function (x) {
                    if (!(x instanceof Media)) {
                        throw new Error("Must add only media");
                    }
                });

                return super.add(...media);
            }

            getTop(count) {
                Validator.validateIfNumber(count);
                Validator.validateNumberInRange(count, 1);

                return this.items
                    .sort(function (first, second) {
                        return first.rating - second.rating;
                    })
                    .slice(0, count)
                    .map(function (element) {
                        return {
                            id: element.id,
                            name: element.name
                        };
                    });
            }

            getSortedByDuration() {
                return this.items
                    .sort(function (first, second) {
                        if (first.duration === second.duration) {
                            return first.duration < second.duration;
                        }

                        return first.id > second.id;
                    })
                    .slice(0);
            }

        }

        return MediaCatalog;
    } ());

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
module.exports = solve;
//  var module = solve();

//  var media = module.getMedia("pesho",2,null,"dds");
//  console.log(media);

