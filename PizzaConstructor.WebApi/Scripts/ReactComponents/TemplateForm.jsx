class TemplateForm extends React.Component {

    render() {
        return (
            <div className="row">
                <div className="col-md-10 col-md-offset-1">
                    <form className="template-form">
                        <input className="form-control"
                               type="text"
                               placeholder="Input pizza name"
                               onChange={this.handleChange.bind(this)}
                               ref={c => this.input = c} />
                    </form>
                </div>
            </div>
        );
    }

    handleChange(event) {
        event.preventDefault();
        this.props.fetchTemplates(this.input.value);
    }
}