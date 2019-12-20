import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  responseJson: any;
  keyword:string='';
  market:string='';
  from:number=0;
  size:number=28;
  pageNumber:0;
  isloading:boolean=false;

  constructor(private api: ApiService) { }

  ngOnInit() {
  }

  pingApi() {

    if(this.market && this.market!='' && (this.keyword==undefined || this.keyword=='')){
      alert("Please input search keyword");
      return;
    }
    this.responseJson=null;
    this.isloading=true;

    this.api.ping$(this.keyword,this.market,this.from,this.size).subscribe(
      res => {
        this.isloading=false;
        this.responseJson = res;
        console.log("response data",this.responseJson);
      }
    );
  }

}

