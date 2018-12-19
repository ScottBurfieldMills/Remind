import { reminderConstants } from '../constants';

export function reminders(state = {}, action) {
    switch (action.type) {
        case reminderConstants.GETALL_REQUEST:
            return {
                loading: true
            };
        case reminderConstants.GETALL_SUCCESS:
            return {
                items: action.reminders
            };
        case reminderConstants.GETALL_FAILURE:
            return {
                error: action.error
            };
        default:
            return state;
    }
}
