import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';

import { userActions } from '../actions';

class LogoutPage extends React.Component {
    constructor(props) {
        super(props);

        // logout status
        this.props.dispatch(userActions.logout(true));
    }

    render() {
	    return (
            <div>
                <h1>Logging you out.</h1>
            </div>
	    );
    }
}

function mapStateToProps(state) {
	const { loggingIn } = state.authentication;
	return {
		loggingIn
	};
}

const connectedLogoutPage = connect(mapStateToProps)(LogoutPage);
export { connectedLogoutPage as LogoutPage }; 