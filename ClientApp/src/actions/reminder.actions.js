import { reminderConstants } from '../constants';
import { reminderService } from '../services';
import { alertActions } from './';

export const reminderActions = {
    getAll
};

function getAll() {
    return dispatch => {
        dispatch(request());

        reminderService.getAll()
            .then(
                reminders => dispatch(success(reminders)),
                error => {
                    dispatch(failure(error.ToString));
                    console.log('reminder error', error.toString());
                    dispatch(alertActions.error(error.toString()));
                }
            );
    };

    function request() { return { type: reminderConstants.GETALL_REQUEST } }
    function success(reminders) { return { type: reminderConstants.GETALL_SUCCESS, reminders } }
    function failure(error) {
        console.log('failure', error);

        return { type: reminderConstants.GETALL_FAILURE, error }
    }
}