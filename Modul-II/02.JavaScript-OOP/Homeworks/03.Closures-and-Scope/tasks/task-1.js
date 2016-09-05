/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var books = [],
            categories = [];


        function addCategory(category) {
            categories.forEach(function (element) {
                if (element === category) {
                    throw new Error("Category already exists");
                }
            });

            categories.push(category);
        }

        function listBooks() {
            return books;
        }

        function addBook(book) {
            book.ID = books.length + 1;
            validateBook(book);

            books.push(book);
            addCategory(book.category);
            return book;
        }

        function listCategories() {
            categories.sort();
            return categories;
        }

        function validateBook(book) {
            // if (book.arguments.length !== 5) {
            //     throw new Error("There number of arguments is invalid");
            // }

            for (var p in books.arguments) {
                if (p === undefined) {
                    throw new Error("The property " + p + " is undefined");
                }
            }

            validateAuthor(book.author);
            validateTitleName(book.title);
            validateIfExists(book.title, books);
            validateISBN(book.isbn);

            validateTitleName(book.category);

        }

        function validateAuthor() {

        }


        function validateISBN(isbn) {
            books.forEach(function (element) {
                if (element.isbn === isbn) {
                    throw new Error("Isbn already exists");
                }
            });

            if (!/[0-9]/.test(isbn)) {
                throw new Error("Invalid patter of the isbn");
            }

            if (isbn.length !== 10 && isbn.length !== 13) {
                throw new Error("Invalid length of the isbn");
            }
        }

        function validateTitleName(title) {
            if (title.length <= 2 || title.length >= 100) {
                throw new Error("The title must be between 2 amd 100 chars");
            }
        }

        function validateIfExists(name, collection) {
            collection.forEach(function (element) {
                if (element.title === name) {
                    throw new Error("The element " + name + " already exists!");
                }
            });
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}
module.exports = solve;
