import React from 'react';
import { connect } from 'react-redux';
import { reminderActions } from '../actions';
import { ReminderFrequencyList } from './ReminderFrequencyList';

class CreateReminder extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
            url: '',
            frequencyId: this.props.user.reminderFrequencyId,
            submitted: false
		};

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.onSelectFrequency = this.onSelectFrequency.bind(this);
	}

    componentDidMount() {
	    this.props.dispatch(reminderActions.getReminderFrequencies());
    }

    handleChange(event) {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit(event) {
        event.preventDefault();

        this.setState({ submitted: true });

        const { url, frequencyId } = this.state;
        const { dispatch } = this.props;

        if (url) {
            dispatch(reminderActions.create(url, frequencyId));
            
            this.setState({
	            url: '',
                submitted: false
            });
        }
    }

    onSelectFrequency(frequencyId) {
	    this.setState({
		    frequencyId: frequencyId
	    });
    }

    render() {
        const { url, submitted } = this.state;

        const isInvalid = submitted && !url;

        return (
            <div className="col-md-12">
                <h2>Create Reminder</h2>

                <form name="form" onSubmit={this.handleSubmit}>
                    <div className="form-group row">
                        <label htmlFor="url" className="col-sm-2">Url</label>
                        <div className="col-sm-10">
                            <input type="text"
                                className={'form-control' + (isInvalid ? ' is-invalid' : '')}
                                value={this.state.url}
                                name="url" onChange={this.handleChange} />

                            {isInvalid &&
                                <div className="invalid-feedback">Url is required</div>}
                        </div>
                    </div>
                    
                    <ReminderFrequencyList frequencies={this.props.frequencies}
						label="Remind"
                        selectedFrequency={this.state.frequencyId}
                        onSelectFrequency={this.onSelectFrequency}></ReminderFrequencyList>
            
                    <div className="form-group">
                        <button className="btn btn-primary">Create</button>
                    </div>
                </form>
            </div>  
		)
    }
}

function mapStateToProps(state) {
    const { frequencies } = state.reminders;
    const { user } = state.authentication;

    return {
        frequencies,
        user
	};
}

const connectedCreateReminder = connect(mapStateToProps)(CreateReminder);
export { connectedCreateReminder as CreateReminder }; 