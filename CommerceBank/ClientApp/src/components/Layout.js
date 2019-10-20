import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { SideBarButtons } from './shared/SideBarButtons';


export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div id="LayoutDivID">
            <NavMenu />
            <SideBarButtons />
            <div className="LayoutDivClassName">
                    {this.props.children}
            </div>
      </div>
    );
  }
}
