import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import {Search} from "../../../../sharded/models/Search";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchObject: Search = new Search()
  @Output() onSearch = new EventEmitter<Search>()

  constructor() { }

  search(): void {
    let search = this.searchObject;
    search.byTag = false;

    if (this.searchObject.searchString.indexOf('#') !== -1) {
        search.searchString = this.searchObject.searchString.split('#').pop().split(' ').shift();

        search.byTag = true
    }
    this.onSearch.emit(search);
    this.searchObject.searchString = ''
  }
  ngOnInit() {
  }

}
