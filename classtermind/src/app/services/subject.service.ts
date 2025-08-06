import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SubjectDto } from '../models/subject-dto.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private apiUrl = 'https://localhost:7150/api/subjects';
    
  constructor(private http: HttpClient) {}

  getSubjects(): Observable<SubjectDto[]> {
    return this.http.get<SubjectDto[]>(this.apiUrl);
  }

  getSubjectByName(name: string): Observable<SubjectDto> {
    return this.http.get<SubjectDto>(`${this.apiUrl}/${name}`);
  }

  addSubject(subject: SubjectDto): Observable<void> {
    return this.http.post<void>(this.apiUrl, subject);
  }

  generateStudyPlan(name: string, hours: number): Observable<{ subject: string, plan: string }> {
  return this.http.get<{ subject: string, plan: string }>(`${this.apiUrl}/${name}/plan/${hours}`);
}
}
