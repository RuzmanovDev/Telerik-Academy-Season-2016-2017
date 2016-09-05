function solve() {
    if (!Array.prototype.find) {
        Array.prototype.find = function (predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.find called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return value;
                }
            }
            return undefined;
        };
    }

    if (!Array.prototype.findIndex) {
        Array.prototype.findIndex = function (predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.findIndex called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return i;
                }
            }
            return -1;
        };
    }

    function indexOfElementWithIdInCollection(collection, id) {
        var i, len;
        for (i = 0, len = collection.length; i < len; i++) {
            if (collection[i].id == id) {
                return i;
            }
        }

        return -1;
    }

    var PlayList, Player, Playable, Audio, Video,
        Validator = {
            validateIfNumber(number){
                if (typeof +number !== "number" || isNaN(+number)) {
                    throw new Error("The value is not a number");
                }
            },
            validateIfString(value){
                if (typeof value !== "string") {
                    throw new Error("The value is not a string!");
                }

                if (value.length < 3 || value.length > 25) {
                    throw new Error("The length must be between 3 and 25");
                }
            },
            validateAudioLength(length){
                if (!length) {
                    throw new Error("The length is invalid!")
                }

                if (+length < 0) {
                    throw  new Error("the length must be >0");
                }
            },

            validateImdbRating(value){
                validateIfNumber(value);
                if (value < 1 || value > 5) {
                    throw new Error("Imdb rating must be between 1 and 5!")
                }
            },
            validatePlayList(playlistToAdd){
                if (!(playlistToAdd instanceof PlayList)) {
                    throw new Error("The playlist to add must be of type playlist");
                }
            },
            validateList(page, size, length){
                if (page === "undefined" || size == "undefined"
                    || page * size > length
                    || page < 0
                    || size <= 0) {
                    throw new Error("Invalid arguments of List method!")
                }
            }
        };
    let NamebleWithIdMixin = function () {
        let id = 0;
        let NamebleWithIdMixin = Base => class extends Base {
            constructor(name) {
                super();
                this._id = (id += 1);
                this.name = name;
            }

            get id() {
                return this._id;
            }

            get name() {
                return this._name;
            }

            set name(value) {
                Validator.validateIfString(value);
                this._name = value;
            }
        };

        return NamebleWithIdMixin;
    }();

    PlayList = (function () {
        class PlayList extends NamebleWithIdMixin(Object) {
            constructor(name) {
                super(name);
                this._playList = [];
            }

            addPlayable(playable) {

                this._playList.push(playable);
                return this;
            }

            getPlayableById(id) {
                Validator.validateIfNumber(id);
                var playable = this._playList.find(pl=> pl.id === id);

                if (!playable) {
                    return null;
                }

                return playable;
            }

            removePlayable(id) {

                if (typeof(id) !== "number") {
                    id = id.id;
                }

                let index = indexOfElementWithIdInCollection(this._playList, id);

                if (index === "undefined" || index < 0) {
                    throw  new Error("there is no such item!");
                }
                // if (indexOfItemToDelete < 0) {
                //     throw  new Error("playable to be deleted not found!");
                // }
                this._playList.splice(index, 1);

                return this;
            }

            listPlayables(page, size) {
                Validator.validateList(page, size, this._playList.length);
                this._playList.sort(function (pl1, pl2) {
                    if (pl1.name === pl2.name) {
                        return pl1.id - pl2.id;
                    }
                    return pl1.name.localeCompare(pl2.name);
                });
                var from = page * size;
                return this._playList.slice(from, (page + 1 ) * size);
            }

            contains(playable, playlist) {
                let item = playlist.find(currentItem => currentItem.id === playable.id);
                if (item) {
                    return true;
                } else {
                    return false
                }
            }

        }

        return PlayList;
    }());

    Player = (function () {
        class Player extends NamebleWithIdMixin(Object) {
            constructor(name) {
                super(name);
                this._playlists = [];
            }

            addPlaylist(playlistToAdd) {
                Validator.validatePlayList(playlistToAdd);
                this._playlists.push(playlistToAdd);

                return this;
            }

            getPlaylistById(id) {
                if (typeof id !== "number") {
                    id = id.id;
                }
                var foundItem = this._playlists.find(function (playable) {
                    return playable.id === id;
                });

                if (foundItem) {
                    return foundItem;
                } else {
                    return null;
                }
            }

            removePlaylist(id) {
                Validator.validateIfNumber(id);
                var seekedPlayList = this._playlists.find(currentPlayList =>currentPlayList.id === id);
                if (!seekedPlayList) {
                    throw  new Error("THe playlist to be deleted is not found in the player!")
                }
                var indexOfSeekedPlaylist = this._playlists.indexOf(seekedPlayList);
                this._playlists.splice(indexOfSeekedPlaylist, 1);
                return this;
            }

            listPlaylists(page, size) {
                Validator.validateList(page, size, this._playlists.length);
                this._playlists.sort(function (pl1, pl2) {
                    if (pl1.title === pl2.title) {
                        return pl1.id - pl2.id;
                    }
                    return pl1.title.localeCompare(pl2.title);
                });
                var from = page * size;
                return this._playlists.slice(from, (page + 1 ) * size);
            }

            contains(playable, playlist) {
                let item = playlist.find(currentItem => currentItem.id === playable.id);
                if (item) {
                    return true;
                } else {
                    return false
                }
            }

            search(pattern) {
                Validator.validateIfString(pattern);

                return this._playlists
                    .filter(function (playlist) {
                        return playlist
                            .listPlayables()
                            .some(function (playable) {
                                return playable.length !== undefined
                                    && playable
                                        .title
                                        .toLowerCase()
                                        .indexOf(pattern.toLowerCase()) >= 0;
                            });
                    })
                    .map(function (playlist) {
                        return {
                            id: playlist.id,
                            name: playlist.name,
                        }
                    });
            }
        }

        return Player;
    }());

    Playable = (function () {
        var id = 0;
        class Playable {
            constructor(title, author) {
                this._id = (id += 1);
                this.title = title;
                this.author = author;
            }

            get title() {
                return this._title;
            }

            set title(value) {
                Validator.validateIfString(value);
                this._title = value;
            }

            get author() {
                return this._author;
            }

            set author(value) {
                Validator.validateIfString(value);
                this._author = value;
            }

            get id() {
                return this._id;
            }

            play() {
                return `${this.id}. ${this.title} - ${this.author}`;
            }
        }
        return Playable;
    }());

    Audio = (function (Parent) {
        class Audio extends Parent {
            constructor(title, author, length) {
                super(title, author);
                this.length = length;
            }

            get length() {
                return this._length;
            }

            set length(value) {
                Validator.validateAudioLength(value);
                this._length = value;
            }

            play() {
                return super.play() + ` - ${this.length}`;
            }
        }
        return Audio;
    }(Playable));

    Video = (function (Parent) {
        class Video extends Parent {
            constructor(title, author, imdbRating) {
                super(title, author);
                this.imdbRating = imdbRating;
            }

            get imdbRating() {
                return this._imdbRating;
            }

            set imdbRating(value) {
                Validator.validateImdbRating(value);
                this._imdbRating = value;
            }

            play() {
                return super.play() + ` - ${this.imdbRating}`;
            }
        }

        return Video;

    }(Playable));

    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new PlayList(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length)
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

var result = solve();
var audio = result.getAudio('asd', 'sdf', 4);
audio = result.getAudio('asd', 'sdf', 4);
console.log(audio.play());

var pl = result.getPlaylist('asd');

var playable = {id: 1, name: 'Rock', author: 'Stephen'};
pl.addPlayable(playable);
console.log(pl.getPlayableById(1));

console.log(pl.listPlayables(0, 10));
pl.removePlayable(1);
console.log(pl.getPlayableById(1));

var list = result.getPlaylist('Rock');
for (var i = 0; i < 35; i += 1) {
    list.addPlayable({id: (i + 1), name: 'Rock' + (9 - (i % 10))});
}

// console.log(list.listPlayables(0, 10));
// returnedPlayables = list.listPlaylables(2, 10);
// returnedPlayables = list.listPlaylables(3, 10);
// console.log(returnedPlayables);


module.exports = solve;