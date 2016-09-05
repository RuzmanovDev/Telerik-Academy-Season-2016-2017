var LinkedList = (function () {
    class listNode {
        constructor(value) {
            this.value = value;
            this.next = null;
        }

    }

    class LinkedList {
        constructor() {
            this._length = 0;
            this._head = null;
            this._tail = null;
        }

        get length() {
            return this._length;
        }

        get first() {
            return this._head.value;
        }

        get last() {
            return this._tail.value;
        }

        append(...args) {
            for (let i = 0; i < args.length; i += 1) {
                var node = new listNode(args[i]),
                    current;

                if (this._head === null) {
                    this._head = node;
                    this._tail = node;
                } else {
                    current = this._head;

                    while (current.next) {
                        current = current.next;
                    }

                    current.next = node;
                    this._tail = node

                }

                this._length += 1;
            }

            return this;
        }

        prepend(...args) {
            for (let i = args.length - 1; i >= 0; i -= 1) {
                var node = new listNode(args[i]),
                    oldHead = this._head;

                node.next = oldHead;
                this._head = node;
                this._length += 1;
            }

            return this;
        }

        _getElementAt(index) {
            if (index >= this.length) {
                throw new Error("index out of range!!!");
            }
            var current = this._head;
            for (let i = 0, len = this.length; i < len; i += 1) {
                if (index === i) {
                    return current;
                } else {
                    current = current.next;
                }
            }
        }

        at(index, value) {
            if (index >= this.length) {
                throw new Error("index out of range!!!");
            }
            if (typeof(value) === "undefined") {
                return this._getElementAt(index).value;
            } else {
                this._getElementAt(index).value = value;
                return this;
            }
        }

        insert(index, ...args) {
            if (index === 0) {
                this.prepend(...args);
            } else if (index === this.length) {
                this.append(...args);
            } else {
                var previousElement = this._getElementAt(index - 1),
                    nextElement = this._getElementAt(index);

                var prevNode = new listNode(args[0]);
                previousElement.next = prevNode;
                for (let i = 1, len = args.length; i < len; i += 1) {
                    var newNode = new listNode(args[i]);
                    prevNode.next = newNode;

                    prevNode = newNode;
                    this._length += 1;
                }
                prevNode.next = nextElement;
                this._length += 1;
            }
            return this;
        }

        * [Symbol.iterator]() {
            var array = this.toArray();
            for (let i = 0, len = array.length; i < len; i += 1) {
                yield array[i];
            }
        }

        toString() {
            var str = "";
            var current = this._head;
            while (current.next) {
                str += current.value + " -> ";
                current = current.next;
            }
            str += current.value;
            return str;
        }

        toArray() {
            var current = this._head,
                array = [];
            while (current.next) {
                array.push(current.value);
                current = current.next;
            }
            array.push(current.value);
            return array;
        }

        removeAt(index) {
            var valueToRemove = this.at(index),
                previousIndex = index - 1,
                nextIntex = index + 1;

            if (previousIndex < 0) {
                this._head = this._head.next;
            }
            else if (nextIntex >= this.length) {
                this._tail = this._getElementAt(previousIndex);
                this._tail.next = null;
            } else {
                var previousValue = this._getElementAt(previousIndex),
                    nextValue = this._getElementAt(nextIntex);

                previousValue.next = nextValue;
            }

            this._length -= 1;
            return valueToRemove;
        }
    }

    return LinkedList;
}());

module.exports = LinkedList;

// const list = new LinkedList();
// list.append(4, 5, 6).prepend(1, 2, 3);
// console.log(list.toString());
// should contain 1, 2, 3, 4, 5, 6 in that order
// const list = new LinkedList();
// list.append(1, 2, 3, 4, 5, 6);
// console.log(list.at(2)); // 3
//
// list.at(2, 'gosho');
// console.log(list.at(2)); // gosho

// const list = new LinkedList().append(1, 4, 5).insert(1, 2, 3);
// console.log(list.toString());// list should contain 1, 2, 3, 4, 5console.log(list.toString());
// console.log(list.length);

// const list = new LinkedList().append(1, 2).insert(0, 3, 4);
// console.log(list.toString());
// console.log(list.length);
//
// list.insert(list.length - 1, 'kremikovci');
//
// console.log(list.first === 3);
// console.log(list.last === 2);
// console.log(list.length === 5);
// console.log(list.toString() === [3, 4, 1, 'kremikovci', 2].join(' -> '));
//
// console.log(list.toString());
// console.log([3, 4, 1, 'kremikovci', 2].join(' -> '));

// const list = new LinkedList().append(6, 7, 8).prepend(1, 2, 3, 4, 5);
//
// for(const value of list) {
//     console.log(value);
// }