import React, { Component } from 'react';
import { connect } from 'react-redux'
import { Button, ButtonGroup } from 'reactstrap'
import { userActions } from '../actions';

class AccountPage extends Component {

    constructor(props) {
        super(props);

        this.state = {
            frequency: '',
            availableFrequencies: ['1d', '3d', '7d']
        };

        this.handleClick = this.handleClick.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
	    const userId = this.props.user.id;

	    this.props.dispatch(userActions.getSettings(userId));
    }
     
    handleClick(event) {
	    event.preventDefault();
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit(event) {
        event.preventDefault();

        const { dispatch } = this.props;

        const userSettings = {
	        defaultReminderFrequency: this.state.frequency
        };

        dispatch(userActions.updateSettings(this.props.user.id, userSettings));
    }

    render() {
        const { possibleNotificationTypes } = this.props.settings || {};
        const { availableFrequencies } = this.state;

	    return (
            <div className="col-md-12">
                <h1>Account</h1>

                <form onSubmit={this.handleSubmit}>
                    <legend>Notification Settings</legend>

                    <div className="form-group row">
                        <label className="col-sm-2">Default frequency</label>

                        <div className="col-sm-10">
	                        <ButtonGroup data-toggle="button">
                                {availableFrequencies.map((frequency) =>
                                    <Button key={frequency} onClick={this.handleClick} name="frequency" value={frequency}
                                        color={this.state.frequency === frequency ? 'primary' : 'default'}>
                                        {frequency}
                                    </Button>
                                )}
	                        </ButtonGroup>
                        </div>
                    </div>

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