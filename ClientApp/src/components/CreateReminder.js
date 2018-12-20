import React from 'react';
import { connect } from 'react-redux';
import { reminderActions } from '../actions';

class CreateReminder extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
			url: ''
		};

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event) {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit(event) {
        event.preventDefault();

        const { url } = this.state;
        const { dispatch } = this.props;

        if (url) {
            dispatch(reminderActions.create(url));
            
            this.setState({
	            url: ''
            });
        }
    }

    render() {
        return (
            <div className="col-md-6">
                <h2>Create Reminder</h2>

                <form name="form" onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="url">Url</label>
                        <input type="text" className="form-control" value={this.state.url} name="url" onChange={this.handleChange} />
                    </div>

                    <div className="form-group">
                        <button className="btn btn-primary">Create Reminder</button>
                    </div>
                </form>
            </div>  
		)
    }
}

const connectedCreateReminder = connect()(CreateReminder);
export { connectedCreateReminder as CreateReminder }; 