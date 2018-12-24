import React, { Component } from 'react';
import { connect } from 'react-redux'
import { userActions } from '../actions';
import { ReminderFrequencyList } from './ReminderFrequencyList';

class AccountPage extends Component {

    constructor(props) {
        super(props);

        this.state = {
            frequency: this.props.user.reminderFrequencyId.toString()
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleSelectFrequency = this.handleSelectFrequency.bind(this);
    }

    componentDidMount() {
	    const userId = this.props.user.id;

	    this.props.dispatch(userActions.getSettings(userId));
    }

    handleSubmit(event) {
        event.preventDefault();

        const { dispatch } = this.props;

        const userSettings = {
	        defaultReminderFrequency: this.state.frequency
        };

        dispatch(userActions.updateSettings(this.props.user.id, userSettings));
    }

    handleSelectFrequency(frequencyId) {
        this.setState({
	        frequency: frequencyId
        });
    }

    render() {
        const settings = this.props.settings || {};

        const { possibleNotificationTypes, possibleReminderFrequencies } = settings;
	    return (
            <div className="col-md-12">
                <h1>Account</h1>

                <form onSubmit={this.handleSubmit}>
                    <legend>Notification Settings</legend>

                    <ReminderFrequencyList frequencies={possibleReminderFrequencies}
						label="Default Frequency"
                        selectedFrequency={this.state.frequency}
                        onSelectFrequency={this.handleSelectFrequency}></ReminderFrequencyList>

                    <fieldset>
                        <legend>Notification Types</legend>

                        {possibleNotificationTypes && possibleNotificationTypes.map((notificationType) =>
                            <div className="form-group row" key={notificationType.id}>
                                <div className="col-sm-2">
                                    {notificationType.name}
                                </div>
                                <div className="col-sm-10 col-md-3">
                                    <input type="text" className="form-control"/>
                                </div>
                            </div>
                            )}
                    </fieldset>

	                <div className="form-group">
		                <button className="btn btn-primary">Save</button>
	                </div>
                </form>
            </div>
	    );
    }
}

function mapStateToProps(state) {
    const { user } = state.authentication;
    //const { settings } = state.users.userSettings || {};

    const settings = state.users.userSettings;

	return {
        user,
        settings
	};
}

const connectedAccountPage = connect(mapStateToProps)(AccountPage);
export { connectedAccountPage as AccountPage }; 