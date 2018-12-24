import { reminderConstants } from '../constants';
import { reminderService } from '../services';
import { alertActions } from './';

export const reminderActions = {
    getAll,
    create,
    getReminderFrequencies
};

function getAll() {
    return dispatch => {
        dispatch(request());

        reminderService.getAll()
            .then(
                reminders => dispatch(success(reminders)),
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }
            );
    };

    function request() { return { type: reminderConstants.GETALL_REQUEST } }
    function success(reminders) { return { type: reminderConstants.GETALL_SUCCESS, reminders } }
    function failure(error) { return { type: reminderConstants.GETALL_FAILURE, error } }
}

function create(url, frequencyId) {
    return dispatch => {
        dispatch(request());

        reminderService.create(url, frequencyId)
            .then(
                reminder => {
                    dispatch(success(reminder));
                    dispatch(alertActions.success('Created reminder'));
                },
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }
            );
    };

    function request() { return { type: reminderConstants.CREATE_REQUEST } }
    function success(reminder) { return { type: reminderConstants.CREATE_SUCCESS, reminder } }
    function failure(error) { return { type: reminderConstants.CREATE_FAILURE, error } }
}

function getReminderFrequencies() {
    return dispatch => {
        dispatch(request());

        reminderService.getFrequencies()
            .then(
                reminderFrequencies => {
                    dispatch(success(reminderFrequencies));
                },
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }
            );
    }

    function request() { return { type: reminderConstants.GETFREQUENCIES_REQUEST } }
    function success(reminder) { return { type: reminderConstants.GETFREQUENCIES_SUCCESS, reminder } }
    function failure(error) { return { type: reminderConstants.GETFREQUENCIES_FAILURE, error } }
}