class TemplateBox extends React.Component {

    constructor() {
        super();

        this.state = {
            templates: []
        };
    }

    componentWillMount() {
        this.fetchTemplates();
    }

    render() {
        return (
            <div className="row container">
                <TemplateForm fetchTemplates={this.fetchTemplates.bind(this)} />
                <div className="row template-box">
                    {this.getTemplates()}
                </div>
            </div>
        );
    }

    fetchTemplates(name) {
        if (name == undefined || name == "")
            var data = null;
        else {
            data = { name: name };
        }
        $.ajax({
            method: 'GET',
            url: '../api/templates',
            data: data,
            success: (templates) => {
                this.setState({ templates });
            }
        });
    }

    getTemplates() {
        return this.state.templates.map((template) => {
            return (<Template
                name={template.Name}
                imageUrl={template.ImageUrl}
                price={template.TotalCost}
                ingredients={template.Ingredients}
                savePizza={this.props.savePizza.bind(this)}
                myAlertTop={this.props.myAlertTop.bind(this)}
                isAuth = {this.props.isAuth}
            />);
        });
    }
}