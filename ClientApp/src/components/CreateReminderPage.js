import React from 'react';
import { connect } from 'react-redux';
import { reminderActions } from '../actions';

class CreateReminderPage extends React.Component {

    constructor(props) {
        super(props);

	    const pathname = window.location.pathname;
	    const pathnameContainsUrl = pathname.includes('http');

	    let url = '';

	    if (pathname.startsWith('/')) {
		    url = pathname.substring(1);
	    }
        
	    this.state = {
            url: url,
            pathnameContainsUrl: pathnameContainsUrl
	    };
    }

    componentDidMount() {
        if (this.state.pathnameContainsUrl) {
	        this.props.dispatch(reminderActions.create(this.state.url));
        }
    }

    render() {
        if (this.props.loading) {
            return (
                <div>
                    <h1>Done</h1>
                </div> 
	        )
        }

        return (
			<div>Thing</div>
	    )
    }
}

function mapStateToProps(state) {
	const { reminders } = state;

	return {
		loading: reminders.loading
	};
}


const connectedCreateReminderPage = connect(mapStateToProps)(CreateReminderPage);
export { connectedCreateReminderPage as CreateReminderPage }; 