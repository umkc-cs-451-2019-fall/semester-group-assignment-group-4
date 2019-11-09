import React, { Component } from 'react';
import './../styles/CollapsibleComponent.css';
export class CollapsibleComponent extends Component {
    

    componentDidMount() { }

    expandOrCollapse() {
        var iconID = "expandOrCollapseIcon" + this.props.componentID;
        var hiddenDiv = "hiddenDiv" + this.props.componentID;
        var collapsibleDiv = document.getElementById(hiddenDiv);
        var arrowIcon = document.getElementById(iconID);
        //Collapse
        if (collapsibleDiv.style.display === "block") {
            arrowIcon.className = "right";
            collapsibleDiv.style.display = "none";
            
        }
        else {
            //Expande
            arrowIcon.className = "down";
            collapsibleDiv.style.display = "block";
           
        }
    }
    render() {
        return (
            <div className="CollapsibleComponent">
                <button type="button" className="collapsible" onClick={this.expandOrCollapse.bind(this)}>{this.props.header}<i className="right" id={"expandOrCollapseIcon" + this.props.componentID}></i></button>
                   
                <div className="content" id={"hiddenDiv" + this.props.componentID}>
                    {this.props.content}
                </div>
            </div>
        );
    }
}