import { authHeader } from '../helpers';

export const reminderService = {
    getAll,
    create
}

function getAll() {
	const requestOptions = {
		method: 'GET',
		headers: authHeader()
    };

	return fetch(`/reminders`, requestOptions).then(handleResponse);
}

function create(url) {
	const requestOptions = {
        method: 'POST',
		headers: {
            ...authHeader(),
			'Content-Type': 'application/json'
    },
		body: JSON.stringify({ url: url })
    };

	return fetch(`/reminders/create`, requestOptions)
		.then(handleResponse);
}

function handleResponse(response) {
	return response.text().then(text => {
		const data = text && JSON.parse(text);
		if (!response.ok) {
            if (response.status === 401) {
	            return Promise.reject('Authentication error');
            } else {
	            const error = (data && data.message) || response.statusText;

                return Promise.reject(error);
            }
		}

		return data;
	});
}