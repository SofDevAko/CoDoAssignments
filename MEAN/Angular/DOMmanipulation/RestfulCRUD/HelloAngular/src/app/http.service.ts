import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';



@Injectable()
export class HttpService {

  constructor(private _http: HttpClient) {

    this.getTasks();
   }

  getTasks(){
    // our http response is an Observable, store it in a variable
    let tempObservable = this._http.get('/tasks');
    // subscribe to the Observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Got our tasks!", data));
    return this._http.get('/tasks');
 }
  addTask(newtask){  //CREATE
    return this._http.post('/tasks', newtask)
  }
  showTask(id){  //READ
    return this._http.get("/tasks/"+id+"")
  }
  updateTask(edittask, id){  //UPDATE
    return this._http.put("/tasks/"+id+"", edittask)
  }
  deleteTask(id) {  //DESTROY
    return this._http.delete("/tasks/"+id)
  }
}
