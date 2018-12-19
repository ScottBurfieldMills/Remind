import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { registration } from './registration.reducer';
import { users } from './users.reducer';
import { alert } from './alert.reducer';
import { reminders } from './reminders.reducer';

const rootReducer = combineReducers({
	authentication,
	registration,
	users,
    alert,
    reminders
});

export default rootReducer;