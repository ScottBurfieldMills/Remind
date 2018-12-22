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
	            <ul>
                    {this.props.reminders.items.map((reminder) => {
	                    return (<li key={reminder.id}>
                            <a href={reminder.url} target="blank" placeholder="https://www.example.com">
                                {reminder.url}
                            </a>
                        </li>);
                    })}
                </ul>
            );
        } else if (this.props.reminders.items && this.props.reminders.items.length === 0 && !loading) {
	        reminderList = (
		        <h2>No reminders!</h2>
	        );
        }

        return (
            <div className="col-md-12">
                <h2>Reminder List</h2>

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
