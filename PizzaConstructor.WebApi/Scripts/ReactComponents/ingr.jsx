
////////////////////////////////////////////////////////////////////////
//const Tabs = React.createClass({
//    displayName: 'Tabs',
//    propTypes: {
//        selected: React.PropTypes.number,
//        children: React.PropTypes.oneOfType([
//            React.PropTypes.array,
//            React.PropTypes.element
//        ]).isRequired
//    },
//    getDefaultProps() {
//        return {
//            selected: 0
//        };
//    },
//    getInitialState() {
//        return {
//            selected: this.props.selected
//        };
//    },
//    handleClick(index, event) {
//        console.log("handleClick");
//        event.preventDefault();
//        this.setState({
//            selected: index
//        });
//    },
//    _renderTitles() {
//        function labels(child, index) {
//            let activeClass = (this.state.selected === index ? 'active' : '');
//            return (
//                <li key={index}>
//                    <a href="#"
//                        className={activeClass}
//                        onClick={this.handleClick.bind(this, index)}>
//                        {child.props.label}
//                    </a>
//                </li>
//            );
//        }
//        return (
//            <ul className="tabs__labels">
//                {this.props.children.map(labels.bind(this))}
//            </ul>
//        );
//    },
//    _renderContent() {
//        return (
//            <div className="tabs__content">
//                {this.props.children[this.state.selected]}
//            </div>
//        );
//    },
//    render() {
//        return (
//            <div className="tabs">
//                {this._renderTitles()}
//                {this._renderContent()}
//            </div>
//        );
//    }
//});

//const Pane = React.createClass({
//    displayName: 'Pane',
//    propTypes: {
//        label: React.PropTypes.string.isRequired,
//        children: React.PropTypes.element.isRequired
//    },
//    render() {
//        return (
//            <div>
//                {this.props.children}
//                {this.props.componentWillMount}
//            </div>
//        );
//    }
 
//});
///////////////////////////////////////////////////////////
//const App = React.createClass({
//    render() {
//        return (
//            <div>
//                <Tabs selected={1}>
//                    <Pane label="Vegetables" >
//                        <IngredientList  category="Vegetables"  />

//                    </Pane>
//                    <Pane label="Meat">
//                            <IngredientList category="Meat" />
//                    </Pane>
//                    <Pane label="Sea Food">
                        
//                            <IngredientList category="SeaFood" />
                  
//                    </Pane>
//                    <Pane label="Souses">
//                        <IngredientList category="Souses" />
//                    </Pane>
//                    <Pane label="Cheese">
                        
//                            <IngredientList category="Cheese" />
                       
//                    </Pane>
//                </Tabs>
//            </div>
//        );
//    }
//});
///////////////////////////////////////////////////////////////////
//class IngredientTabs extends React.Component {

//    render() {
//        return (

//            <div>

//                <IngredientList />
//            </div>

//        );
//    }

//}
//class Ingredient extends React.Component {

//    constructor(props) {
//        super(props);
//        this.state = { Ingredients: props.ingredient };
//    }

//    render() {
//        return <div>
//            <p><b>{this.state.Ingredients.Name}  </b>
//                {this.state.Ingredients.Price}</p>
//        </div>;
//    }
//}

//class IngredientList extends React.Component {

//    constructor(props) {
//        super(props);
//        this.state = {
//            ingredient: []
//        };

//    }

//    // загрузка данных
//    loadData() {
//        console.log("loadData: " + this.props.category);
//        $.ajax({
//            method: "GET",
//            url: "../api/filter",
//            data: { name: this.props.category },
//            success: (ingredient) => {
//                console.log("success");
//                this.setState({ ingredient });
//            },
//            error: (p1, status, error) => {
//                console.log(status);
//                console.log(error);
//            }
//        });
//    }

//    componentWillUpdate() {
//        console.log("componentWillUpdate: " + this.props.category);
//    }

//    componentWillMount() {
//        console.log("componentWillMount: " + this.props.category);
//        this.loadData();
//    }
   
//    componentWillUnmount() {
//        console.log("componentWillUnmount: " + this.props.category);
//    }
    

//    render() {
//        console.log("render: " + this.props.category);

//        return <div>

//            <h2>List ingredients</h2>
//            <div>
//                {
//                    this.state.ingredient.map(function (ingred, index) {
//                        //return <Ingredient key={ingred.ID} ingredient={ingred} />
//                        console.log(index);
//                        console.log(ingred);
//                        return <Ingredient key={ingred.Name.toString()} ingredient={ingred} />;
//                    })
//                }
//            </div>
//        </div>;
//    }
//}


//ReactDOM.render(
//    <App />,
//    document.getElementById("content")
//);

//////////////////////////////////////////////////////////////////////

//It wasn`t commented ↓

const Tabs = React.createClass({
    displayName: 'Tabs',
    propTypes: {
        selected: React.PropTypes.number,
        children: React.PropTypes.oneOfType([
            React.PropTypes.array,
            React.PropTypes.element
        ]).isRequired
    },
    getDefaultProps() {
        return {
            selected: 0
        };
    },
    getInitialState() {
        return {
            selected: this.props.selected
        };
    },
    handleClick(index, event) {
        console.log("handleClick");
        event.preventDefault();
        this.setState({
            selected: index
        });
    },
    _renderTitles() {
        function labels(child, index) {
            let activeClass = (this.state.selected === index ? 'active' : '');
            return (
                <li key={index}>
                    <a href="#"
                        className={activeClass}
                        onClick={this.handleClick.bind(this, index)}>
                        {child.props.label}
                    </a>
                </li>
            );
        }
        return (
            <ul className="tabs__labels">
                {this.props.children.map(labels.bind(this))}
            </ul>
        );
    },
    _renderContent() {
        return (
            <div className="tabs__content">
                {this.props.children[this.state.selected]}
            </div>
        );
    },
    render() {
        return (
            <div className="tabsByKris">
                {this._renderTitles()}
                {this._renderContent()}
            </div>
        );
    }
});

const Pane = React.createClass({
    displayName: 'Pane',
    propTypes: {
        label: React.PropTypes.string.isRequired,
        children: React.PropTypes.element.isRequired
    },
    render() {
        return (
            <div>
                {this.props.children}
            </div>
        );
    }
});

const App = React.createClass({
    render() {
        return (
            <div className="col-md-4">
                <Tabs selected={0}>
                    <Pane label="Dough">
                        <IngredientList category="Dough" />
                    </Pane>
                    <Pane label="Vegetables">
                        <IngredientList category="Vegetables" />
                    </Pane>
                    <Pane label="Meat">
                        <div>
                            <IngredientList category="Meat" />
                        </div>
                    </Pane>
                    <Pane label="Sea Food">
                        <div>
                            <IngredientList category="SeaFood" />
                        </div>
                    </Pane>
                    <Pane label="Souses">
                        <IngredientList category="Souses" />
                    </Pane>
                    <Pane label="Cheese">
                        <div>
                            <IngredientList category="Cheese" />
                        </div>
                    </Pane>
                </Tabs>
            </div>
        );
    }
});










class Ingredient extends React.Component {

    constructor(props) {
        super(props);
        this.state = { Ingredients: props.ingredient };
    }

    render() {
        return <div /*className="center thumbnail template hovereffect"
            src={this.props.imageUrl}
          onLoad={this.handleImageLoaded.bind(this)}
          onError={this.handleImageErrored.bind(this)}
            <img id="drag1" src="//placehold.it/336X69/ff0000" draggable="true" ondragstart="drag(event)" width="336" height="69" />*/>

            <h4>{this.state.Ingredients.Name}</h4>
            <img src={this.state.Ingredients.ImageUrlMain} onLoad={this.handleImageLoaded}
                alt={this.state.Ingredients.ImageUrlMain} data-id={this.state.Ingredients.Name} draggable="true" width="300" height="300" onDragStart={(event) => {
                    console.log('dragstart');
                    event.dataTransfer.setData("text", event.target.id);
                }} id={this.state.Ingredients.Name}/>
            <p>Price: {this.state.Ingredients.Price} $</p>
              
            </div>



        //<div>
        //    <p><b>{this.state.Ingredients.Name}  </b>
        //        {this.state.Ingredients.Price}
        //    </p>
        //    <img src={this.state.Ingredients.imageUrl} alt={this.state.Ingredients.imageUrl} />
        //</div>;
    }
}

class IngredientList extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            ingredient: []
        };

    }

    // загрузка данных
    loadData() {
        console.log("loadData: " + this.props.category);
        $.ajax({
            method: "GET",
            url: "../api/filter",
            data: { name: this.props.category },
            success: (ingredient) => {
                console.log("success");
                this.setState({ ingredient });
            },
            error: (p1, status, error) => {
                console.log(status);
                console.log(error);
            }
        });
    }

    componentWillUpdate() {
        console.log("componentWillUpdate: " + this.props.category);
        this.loadData();
    }

    componentWillMount() {
        console.log("componentWillMount: " + this.props.category);
        this.loadData();
    }

    componentWillUnmount() {
        console.log("componentWillUnmount: " + this.props.category);
    }

    render() {
        console.log("render: " + this.props.category);
        //this.loadData();
        return <div>

            <h2>List ingredients</h2>
            <div>
                {
                    this.state.ingredient.map(function (ingred, index) {
                        //return <Ingredient key={ingred.ID} ingredient={ingred} />
                        console.log(index);
                        console.log(ingred);
                        return <Ingredient key={ingred.Name.toString()} ingredient={ingred} />
                    })
                }
            </div>
        </div>;
    }
}


ReactDOM.render(
    <App />,
    document.getElementById("content")
);