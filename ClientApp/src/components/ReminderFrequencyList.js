import React from 'react';
import { Button, ButtonGroup } from 'reactstrap'

class ReminderFrequencyList extends React.Component {

    constructor(props) {
        super(props);

	    this.state = {
		    frequency: 0
        };

	    this.handleClick = this.handleClick.bind(this);
    }

    handleClick(event) {
	    event.preventDefault();
	    const { value } = event.target;

        this.props.onSelectFrequency(value);
    }

    render() {
	    const { frequencies, label } = this.props;

	    var getColour = (frequency) => {
            return this.props.selectedFrequency === frequency.id.toString()
			    ? 'primary'
			    : 'default';
	    }

	    return (
		    <div className="form-group row">
                <label className="col-sm-2">{label}</label>

                <div className="col-sm-10">
                    <ButtonGroup data-toggle="button">
                        {frequencies &&
	                        frequencies.map((frequency) =>
		                        <Button key={frequency.id} onClick={this.handleClick} name="frequency" value={frequency
			                        .id}
                                color={getColour(frequency)}>
                                {frequency.name}
                            </Button>
	                        )}
                    </ButtonGroup>
                </div>
            </div>
	    );
    }
}

export { ReminderFrequencyList };