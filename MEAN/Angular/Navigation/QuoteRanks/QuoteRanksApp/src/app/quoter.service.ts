import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuoterService {

  constructor(private _http: HttpClient) {
    this.getAuthors();
  }

  getAuthors(){
    return this._http.get('/authors');
  }
  addAuthor(newauthor){
    return this._http.post('/authors', newauthor)
  }
  showAuthor(id){
    return this._http.get("/authors/"+id+"/quotes")
  }
  updateAuthor(editauthor, id){
    return this._http.put("/authors/"+id+"", editauthor)
  }
  deleteAuthor(id) {
    return this._http.delete("/authors/"+id)
  }
  addQuote(data){
    return this._http.post("/authors/quotes",data)
  }
  showQuote(id){
    return this._http.get("/authors/quotes/"+id)
  }
  updateQuote(id, data){
    return this._http.put("/authors/quotes/"+id,data)
  }
  deleteQuote(id){
    return this._http.delete("/authors/quotes/"+id)
  }

}