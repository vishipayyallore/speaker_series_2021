'use strict';

const request = require('supertest');
const app = require('../../src/app');
const mockMongoDb = require('./__mocks__/MongoDbMock');

describe('Testing /src/app.js', () => {

    const apiServer = request(app);

    beforeAll(async () => await mockMongoDb.connect());

    afterEach(async () => await mockMongoDb.clearDatabase());

    afterAll(async () => await mockMongoDb.closeDatabase());

    describe('Testing API Routes', () => {

        // "/" Routes
        describe('App :: "/" Routes', () => {

            const defaultMessage = 'Welcome to Books Web API.';

            test('API Should return default response', async function (done) {
                const response = await apiServer.get('/api');

                expect(response.status).toBe(200);
                expect(JSON.parse(response.text)).toBe(defaultMessage);

                done();
            });

        });

        // "/api/books" Routes
        describe('Book Routers :: "/api/books" Routes', () => {

            const Book = require('../../src/models/book.Model');

            const _book = {
                '_id': '5f0745314c16a3084cfa41fc',
                'author': 'Dummy Author',
                'title': 'Node JS',
                'dateOfPublish': '01-Jan-2021',
                'language': "JavaScript",
                'read': false
            };

            test('Book Router Should return 500 when invalid id is sent', async function (done) {
                const response = await apiServer.get('/api/books/InvalidId');

                expect(response.status).toBe(500);

                done();
            });

            test('Book Router Should return 404 when no data available', async function (done) {
                const response = await apiServer.get('/api/books/5f0745314c16a3084cfa41fc');

                expect(response.status).toBe(404);

                done();
            });

            test('Book Router Should return 200 when data available', async function (done) {
                Book.create(_book);

                const response = await apiServer.get('/api/books/5f0745314c16a3084cfa41fc');

                expect(response.status).toBe(200);

                done();
            });

        });

    });

});
