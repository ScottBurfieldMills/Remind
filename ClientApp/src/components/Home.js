import React, { Component } from 'react';
import { ReminderList } from './ReminderList'
import { CreateReminder } from './CreateReminder'
import { connect } from 'react-redux'

class Home extends Component {
    static displayName = Home.name;

    render() {
        const user = localStorage.getItem('user');

        return (
            <div>
                {user &&
                    <div>
	                    <CreateReminder></CreateReminder>
	                    <ReminderList></ReminderList>
					</div>
                }
                {!user &&
                    <div>
	                    <h1>Reminders</h1>
						<p>Login or sign up to continue.</p>
					</div>
                }
            </div>
        );
    }
}

const connectedHome = connect()(Home);
export { connectedHome as Home}; 