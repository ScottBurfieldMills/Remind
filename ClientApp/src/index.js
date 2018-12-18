import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { Router } from 'react-router-dom';
import { store } from './helpers';
import { App } from './App';
import registerServiceWorker from './registerServiceWorker';
import { history } from './helpers';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
    <Provider store={store}>
        <Router basename={baseUrl} history={history}>
            <App />
	    </Router>
    </Provider>,
  rootElement);

registerServiceWorker();
