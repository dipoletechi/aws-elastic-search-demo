import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  ping$(keyword:string,market:string,from:number,size:number): Observable<any> {
    return this.http.get('http://localhost:53658/api/Search/'+keyword+' /'+market+'/'+from+'/'+size);
  }

}
