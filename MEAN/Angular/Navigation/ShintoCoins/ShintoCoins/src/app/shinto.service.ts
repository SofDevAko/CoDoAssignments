import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ShintoService {

  trans = [];
  svalue = 1;
  samount = 0;
  id=1;
  constructor() {

  }
  getInfo(){
    let data = {trans:this.trans,svalue:this.svalue,samount:this.samount}
    return {data:data}
  }
  getAmount(){
    let data = this.samount;
  }
  getTrans(){
    return this.trans;
  }
  showTrans(id){
    for (let item in this.trans)
    {
      if(item["id"] == id)
      {
        return item;
      }
    }
    return false;
  }
  buyCoin(req){
    this.samount += req['amount'];
    req['id'] = this.id;
    this.trans.push(req);
    this.svalue+=req['amount'];
    this.id++;
    return this.samount;
  }
  sellCoin(req){
    this.samount-=req['amount'];
    req['id'] = this.id;
    this.trans.push(req);
    this.id++;
    this.svalue-=req['amount'];
    return this.samount;
  }
  mineCoin(req){
    this.samount++;
    req['id'] = this.id;
    this.trans.push(req);
    this.id++;
    this.svalue++;
    return this.samount;
  }

}
