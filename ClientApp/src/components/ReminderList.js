import React from 'react';
import { connect } from 'react-redux';
import { reminderActions } from '../actions';

class ReminderList extends React.Component {

    componentDidMount() {
        this.props.dispatch(reminderActions.getAll());
    }

    render() {
        let reminderList;

        const loading = this.props.reminders.loading;

        if (loading) {
	        reminderList = (
		        <h2>Loading</h2>
	        );
        }

        if (this.props.reminders.items && this.props.reminders.items.length > 0) {
            reminderList = (
	            <div className="reminder-list">
                    {this.props.reminders.items.map((reminder) => {
                        return (<div key={reminder.id} className="card">
                            <div className="card-body">
	                            {reminder.reminderSent && <span>! </span>}

	                            <a href={reminder.url} target="blank" placeholder="https://www.example.com">
		                            {reminder.url}
	                            </a>
							</div>
                        </div>);
                    })}
                </div>
            );
        } else if (this.props.reminders.items && this.props.reminders.items.length === 0 && !loading) {
	        reminderList = (
		        <h2>No reminders!</h2>
	        );
        }

        return (
            <div className="col-md-12">
                <h2>Reminders</h2>

                {reminderList}
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        reminders: state.reminders
    };
}

const connectedReminderList = connect(mapStateToProps)(ReminderList);
export { connectedReminderList as ReminderList };
