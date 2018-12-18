import React, { Component } from 'react';
import { Route, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { LoginPage } from './components/LoginPage';
import { LogoutPage } from './components/LogoutPage';
import { RegisterPage } from './components/RegisterPage';
import { history } from './helpers';
import { alertActions } from './actions';

class App extends Component {
  static displayName = App.name;

  constructor(props) {
	  super(props);

	  const { dispatch } = this.props;
	  history.listen((location, action) => {
		  // clear alert on location change
		  dispatch(alertActions.clear());
	  });
  }

  render () {
    return (
        <Layout>
            <div>
                <Route exact path='/' component={Home} />
            	<Route path='/login' component={LoginPage} />
                <Route path='/logout' component={LogoutPage} />
                <Route path='/register' component={RegisterPage} />
            </div>
      </Layout>
    );
  }
}

function mapStateToProps(state) {
	const { alert } = state;
	return {
		alert
	};
}

const connectedApp = withRouter(connect(mapStateToProps)(App));
export { connectedApp as App }; 