import { reminderConstants } from '../constants';

export function reminders(state = {}, action) {
    switch (action.type) {
        case reminderConstants.GETALL_REQUEST:
            return {
                loading: true
            };
        case reminderConstants.GETALL_SUCCESS:
            return {
                ...state,
                items: action.reminders
            };
        case reminderConstants.GETALL_FAILURE:
            return {
                error: action.error
            };
        case reminderConstants.CREATE_REQUEST:
            return {
                ...state,
                loading: true
	        };
        case reminderConstants.CREATE_SUCCESS:
            if (!state.items) {
	            state.items = [];
            }

            state.items.push(action.reminder);

            return {
                ...state
            }
        case reminderConstants.GETFREQUENCIES_SUCCESS:
            return {
                ...state,
                loading: false, 
                frequencies: action.reminder 
            }
        default:
            return state;
    }
}
