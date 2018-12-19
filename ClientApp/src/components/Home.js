import React, { Component } from 'react';
import { ReminderList } from './ReminderList'

export class Home extends Component {
    static displayName = Home.name;

    render() {
        const user = localStorage.getItem('user');

        return (
            <div>
                {user &&
                    <ReminderList></ReminderList>
                }
            </div>
        );
    }
}
