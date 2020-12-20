'use strict';

const Book = require('../../src/models/book.Model');
const booksController = require('../../src/controllers/books.Controller')(Book);
const httpMock = require('node-mocks-http');

describe('Testing books.Controller /src/controllers/books.Controller.js', () => {

    // Variables.
    let request, response;

    const _book = {
        'author': 'Dummy Author',
        'title': 'Node JS',
        'dateOfPublish': '01-Jan-2020',
        'language': "JavaScript",
        'read': false
    };

    const _bookInvalid = {
        title: 'Node JS',
        dateOfPublish: '01-Jan-2020',
        language: "JavaScript",
        read: false
    };

    const _bookExists = {
        dateOfPublish: '2020 - 07 - 07T03: 37: 43.000Z',
        language: 'Python',
        read: false,
        _id: '5f03ee290d4b4a1198c4e1e8',
        author: 'Viswanatha Swamy',
        title: '4th Book',
        __v: 0
    };

    beforeEach(() => {
        request = httpMock.createRequest();
        response = httpMock.createResponse();

        request.book = _book;
        Book.find = jest.fn();
    });

    afterEach(() => {
        Book.find.mockClear();

        request.book = {};
    });

    // getBookById() return 200
    describe('Books Controller :: getBookById()', () => {

        test('getBookById() function is defined', async (done) => {

            expect(typeof booksController.getBookById).toBe('function');

            done();
        });

        test('getBookById() function should return 200', async (done) => {

            await booksController.getBookById(request, response);

            expect(response.statusCode).toBe(200);
            expect(response._getJSONData()).toStrictEqual(_book);

            done();
        });

    });

    // get() Returns all the books. 200, 404 OR 500
    describe('Books Controller :: get()', () => {

        test('get() function is defined', async () => {

            expect(typeof booksController.get).toBe('function');

        });

        test('get() function should return 404', async (done) => {

            Book.find = jest.fn().mockReturnValue([]);

            await booksController.get(request, response);

            expect(response.statusCode).toBe(404);

            done();
        });

        test('get() function should return 200', async (done) => {
            Book.find = jest.fn().mockResolvedValue([_book]);

            await booksController.get(request, response);

            expect(response.statusCode).toBe(200);

            done();
        });

        test('get() function should return 500', async (done) => {
            Book.find = jest.fn().mockRejectedValue('Dummy Error');

            await booksController.get(request, response);

            expect(response.statusCode).toBe(500);

            done();
        });

    });

    // post() return 200, 400, and 500
    describe('Books Controller :: post()', () => {

        test('post() function is defined', async (done) => {

            expect(typeof booksController.post).toBe('function');

            done();
        });

        test('post() function should return 400 when Invalid request is sent', async (done) => {

            request.body = _bookInvalid;

            await booksController.post(request, response);

            expect(response.statusCode).toBe(400);

            done();
        });

        test('post() function should return 400 when record already exists', async (done) => {

            request.body = _book;

            Book.findOne = jest.fn().mockReturnValue(_bookExists);

            await booksController.post(request, response);

            expect(response.statusCode).toBe(400);

            console.log(`Response: ${JSON.stringify(response._getJSONData())}`);

            done();
        });

        test('post() function should return 201 when record does not exists', async (done) => {

            request.body = _book;

            Book.findOne = jest.fn().mockReturnValue(null);
            Book.create = jest.fn().mockReturnValue(_book);

            await booksController.post(request, response);

            expect(response.statusCode).toBe(201);

            done();
        });

        test('post() function should return 500 when it fail to create', async (done) => {

            request.body = _book;

            Book.findOne = jest.fn().mockReturnValue(null);
            Book.create = jest.fn().mockRejectedValue('Unable to save');

            await booksController.post(request, response);

            expect(response.statusCode).toBe(500);

            done();
        });

    });

});

// console.log(`Response: ${JSON.stringify(response)}`);
// expect(response._getJSONData()).toStrictEqual(_book);
// console.log(`Request.Book: ${JSON.stringify(request.book)}`);
// expect(response._getJSONData()).toStrictEqual(_book);
// console.log(`Response: ${JSON.stringify(response._getJSONData())}`);
// console.log(`Response: ${JSON.stringify(response._getJSONData())}`);
// console.log(`Response: ${JSON.stringify(response._getJSONData())}`);
// console.log(`Output Received: ${JSON.stringify(response._getJSONData())}`);