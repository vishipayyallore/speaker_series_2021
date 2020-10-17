'use strict';

const sinon = require('sinon');
const proxyquire = require('proxyquire')
const httpMock = require('node-mocks-http');

describe('Testing /src/routes/bookRouter.js', () => {

    let expressStub, controllerStub, RouterStub, rootRouteStub, idRouteStub
    let request, response, next;

    describe('router', () => {

        beforeEach(() => {

            rootRouteStub = {
                "get": sinon.stub().callsFake(() => rootRouteStub),
                "post": sinon.stub().callsFake(() => rootRouteStub)
            };

            idRouteStub = {
                "get": sinon.stub().callsFake(() => idRouteStub),
                "use": sinon.stub().callsFake(() => idRouteStub)
            };

            RouterStub = {
                route: sinon.stub().callsFake((route) => {
                    if (route === '/books/:bookId') {
                        return idRouteStub
                    }
                    return rootRouteStub
                })
            };

            expressStub = {
                Router: sinon.stub().returns(RouterStub)
            };

            controllerStub = {
                post: sinon.mock(),
                get: sinon.mock(),
                getBookById: sinon.mock()
            };

            proxyquire('../../src/routes/book-Router.js',
                {
                    'express': expressStub,
                    '../controllers/books.Controller.js': controllerStub
                }
            );

            request = httpMock.createRequest();
            response = httpMock.createResponse();
            next = sinon.mock();

        });

        test('should map root get() router with controller::get()', () => {

            rootRouteStub.get('/books', controllerStub.get);

            expect(RouterStub.route.calledWith('/books'));
            expect(rootRouteStub.get.calledWith(controllerStub.get));
        });

        test('should map root getBookById() router with controller::getBookById()', () => {

            idRouteStub.use('/books/:bookId', (request, response, next) => { });

            idRouteStub.get('/books/:bookId', controllerStub.getBookById);

            expect(RouterStub.route.calledWith('/books/:bookId'));
            expect(idRouteStub.get.calledWith(controllerStub.getBookById));
        });

        test('should map root post() router with controller::post()', () => {

            rootRouteStub.post('/books', controllerStub.post);

            expect(RouterStub.route.calledWith('/books'));
            expect(rootRouteStub.post.calledWith(controllerStub.post));

        });

    });

});

