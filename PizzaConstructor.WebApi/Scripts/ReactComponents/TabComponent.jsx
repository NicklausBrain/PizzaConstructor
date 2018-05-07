class TabComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            //categoryIngredients: [],
            selectedIndex: 0
        };

        //this._loadCategoryIngredients();
    }

    render() {        
        return (
            <div className="tab">                
                {
                    this.props.categoryIngredients.map((categoryIngr, i) => {
                        if (i == this.state.selectedIndex) {
                            return (
                                <button
                                    className="tablinks active"
                                    onClick={this.click.bind(this)}
                                    key={i} 
                                    id={i}
                                >{this.props.categoryIngredients[i].Category.Name}</button>   
                            );
                        } else {
                            return (
                                <button
                                    className="tablinks"
                                    onClick={this.click.bind(this)}
                                    key={i}
                                    id={i}
                                >{this.props.categoryIngredients[i].Category.Name}</button>
                            );  
                        }
                    })
                }
                {
                    this.props.categoryIngredients.map((categoryIngr, i) => {
                        return (
                            <TabContentComponent
                                key={i}
                                selectedIndex={this.state.selectedIndex}
                                currentIndex={i}
                                ingredients={this.props.categoryIngredients[i].Ingredients} />
                        );
                    })
                }
            </div>
        );
    }

    click(evt) {
        //console.log("click");
        var newIndex = evt.target.id;
        this.setState({
            selectedIndex: newIndex
        });
    }

    //_loadCategoryIngredients() {
    //    //console.log("loadCategories");

    //    $.ajax({
    //        type: "GET",
    //        url: "/api/categoryingredients",
    //        success: (categoryIngredients) => {
    //            this._initCategoryIngredients(categoryIngredients);
    //        }
    //    });
    //}

    //_initCategoryIngredients(categoryIngredients) {
    //    //console.log("init");
    //    //console.log(categoryIngredients);
    //    this.setState({
    //        categoryIngredients: categoryIngredients,
    //        selectedIndex: 0
    //    });        
    //}
}