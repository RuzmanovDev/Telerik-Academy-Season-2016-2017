## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?
	*	Hierarchical  (tree)
	*	Network / graph
	*	Relational (table)
	*	Object-oriented

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
 Relational Database Management Systems (`RDBMS`) manage data stored in tables
	*	Creating / altering / deleting tables and relationships between them (database schema)
	*	Adding, changing, deleting, searching and retrieving of data stored in the tables
	*	Support for the SQL language
	*	Transaction management (optional)

1.  Define what is "table" in database terms.
	*	Database `tables` consist of data, arranged in rows and columns
	*	All rows have the same structure
	*	Columns have name and type (number, string, date, image, or other)

1.  Explain the difference between a primary and a foreign key.
	*	Primary key is a column of the table that uniquely identifies its rows (usually its is a number)
	* The `foreign key` is an identifier of a record located in another table (usually its primary key)

1.  Explain the different kinds of relationships between tables in relational databases.
	* By using relationships we avoid repeating data in the database 
		* For example the name of the country is not repeated for each town (its number is used instead)
	* Relationships have multiplicity:
		* One-to-many – e.g. country / towns
		* Many-to-many – e.g. student / course
		* One-to-one – e.g. example human / student

1.  When is a certain database schema normalized?
	*	`Normalization` of the relational schema removes repeating data
	* What are the advantages of normalized databases?
		*	Non-normalized schemas can contain many data repetitions, e.g.

1.  What are database integrity constraints and when are they used?
	*	`Integrity constraints` ensure data integrity in the database tables
		*	Enforce data rules which cannot be violated
	*	`Primary key constraint`
		*	Ensures that the primary key of a table has unique value for each table row
	*	`Unique key constraint`
		*	Ensures that all values in a certain column (or a group of columns) are unique
	*	`Foreign key constraint`
		*	Ensures that the value in given column is a key from another table
	*	`Check constraint`
		*	Ensures that values in a certain column meet some predefined condition
1.  Point out the pros and cons of using indexes in a database.
	*	`Indices` speed up searching of values in a certain column or group of columns 
	*	Usually implemented as B-trees
	*	Indices can be built-in the table (`clustered`) or stored externally (`non-clustered`)
	*	Adding and deleting records in indexed tables is slower!
	*	Indices should be used for big tables only (e.g. 50 000 rows)

1.  What's the main purpose of the SQL language?
	*	Creating, altering, deleting tables and other objects in the database
	*	Searching, retrieving, inserting, modifying and deleting table data (rows)

1.  What are transactions used for?
	*	`Transactions` are a sequence of database operations which are executed as a single unit:
		*	Either all of them execute successfully
		*	Or none of them is executed at all
	*	Example:
		*	A bank transfer from one account into another (withdrawal + deposit)
		*	If either the withdrawal or the deposit fails the entire operation should be cancelled

1.  What is a NoSQL database? 
	*	`NoSQL (non-relational) databases`

1.  Explain the classical non-relational data models.
	*	`NoSQL (non-relational) databases`
		*	Use `document-based` model (non-relational)
		*	Schema-free document storage
			*	Still support CRUD operations
				*	Create, Read, Update, Delete
			*	Still support indexing and querying
			*	Still supports concurrency  and transactions
		*	Highly optimized for append / retrieve
		*	Great performance and scalability
		*	NoSQL == “No SQL” or “Not Only SQL”?

1.  Give few examples of NoSQL databases and their pros and cons.
	*	[Redis](http://redis.io/)
		*	Ultra-fast in-memory data structures server
	*	[MongoDB](https://www.mongodb.org/)
		*	Mature and powerful JSON-document database
	*	[CouchDB](http://couchdb.apache.org/)
		*	JSON-based document database with REST API
	*	[Cassandra](http://cassandra.apache.org/)
		*	Distributed wide-column database
	*	DB Ranking: http://db-engines.com/en/ranking
