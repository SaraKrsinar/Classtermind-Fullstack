import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectService } from '../../services/subject.service';
import { SubjectDto } from '../../models/subject-dto.model';
import { RouterModule } from '@angular/router';
import { SubjectCardComponent } from '../subject-card/subject-card.component';

@Component({
  selector: 'app-subject-list',
  standalone: true,
  imports: [
    CommonModule, 
    RouterModule,
    SubjectCardComponent
  ],
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {
  subjects: SubjectDto[] = [];
  isLoading = true;
  errorMessage: string = '';

  constructor(private subjectService: SubjectService) {}

  ngOnInit(): void {
    this.subjectService.getSubjects().subscribe({
      next: (data) => {
        this.subjects = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Не може да се вчитаат предметите.';
        this.isLoading = false;
      }
    });
  }
}
