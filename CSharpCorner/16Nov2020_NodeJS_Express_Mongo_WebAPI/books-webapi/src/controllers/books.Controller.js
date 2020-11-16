'use strict';

const bookSchemaValidator = require('../models/book.SchemaValidator');

function booksController(Book) {

    async function post(request, response) {

        console.log(`Input Received: ${JSON.stringify(request.body)}`);

        // We need to verify both Author Name and Title
        const isBookValid = bookSchemaValidator.validate(request.body);

        if (isBookValid.error) {
            console.log("validation result", isBookValid);
            return response.status(400).json(isBookValid.error);
        }

        // Verify if book's title with same author already exists.
        const similarBookExist = await Book.findOne({ author: request.body.author, title: request.body.title, language: request.body.language });

        if (similarBookExist) {
            console.log(`Does Similar Book Exists: ${similarBookExist}`);
            return response.status(400).json(`Book with "${request.body.title}" title exists from "${request.body.author}" author.`);
        }

        try {
            const book = await (Book.create(request.body))

            console.log(`Sending Output: ${JSON.stringify(book)}`);
            return response.status(201).json(book);

        } catch (error) {
            return response.status(500).json(error);
        }

    }

    async function get(request, response) {
        try {

            const allBooks = await Book.find({});

            if (allBooks && allBooks.length > 0) {
                return response.status(200).json(allBooks);
            } else {
                return response.status(404).json();
            }

        } catch (error) {
            return response.status(500).json(error);
        }
    }

    async function getBookById(request, response) {
        return response.status(200).json(request.book);
    }

    async function updateBookById(request, response) {

        console.log(`Book Id: ${JSON.parse(JSON.stringify(request.book))._id} | Complete Book: ${JSON.stringify(request.book)}`);

        Book.findByIdAndUpdate(request.params.bookId, request.body, {
            new: true,
            useFindAndModify: false,
            runValidators: true
        },
            function (error, book) {
                if (error) {
                    return response.status(500).json(error);
                } else {
                    return response.status(200).json({ 'success': true, 'Message': 'Book updated Successfully', data: book });
                }
            });

    }

    async function deleteBookById(request, response) {

        console.log(`Book Id: ${JSON.parse(JSON.stringify(request.book))._id} | Completed Book: ${JSON.stringify(request.book)}`);

        Book.findByIdAndDelete(request.book._id, function (error, book) {
            if (error) {
                return response.status(500).json(error);
            }
            else {
                return response.status(204).json({ 'success': true, 'Message': 'Book Deleted Successfully' });
            }
        });

    }

    return { post, get, getBookById, updateBookById, deleteBookById };
}

module.exports = booksController;
