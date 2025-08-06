import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectService } from '../../services/subject.service';
import { SubjectDto } from '../../models/subject-dto.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subject-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './subject-detail.component.html',
  styleUrls: ['./subject-detail.component.css']
})
export class SubjectDetailComponent implements OnInit {
  subject?: SubjectDto;
  studyPlan: string = '';
  availableHours: number = 10;//moze da se smeni ponatamu i da vnesuva input userot kolku saati ima slobodni
  isLoading = true;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private subjectService: SubjectService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const name = this.route.snapshot.paramMap.get('name');
    if (name) {
      this.subjectService.getSubjectByName(name).subscribe({
        next: (data) => {
          this.subject = data;
          this.isLoading = false;
          this.loadStudyPlan(name);
        },
        error: () => {
          this.errorMessage = 'Subject could not be found.';
          this.isLoading = false;
        }
      });
    } else {
      this.errorMessage = 'No subject name provided.';
      this.isLoading = false;
    }
  }

  loadStudyPlan(name: string): void {
    this.subjectService.generateStudyPlan(name, this.availableHours).subscribe({
      next: (result) => {
        this.studyPlan = result.plan;
      },
      error: () => {
        this.studyPlan = 'Failed to generate study plan.';
      }
    });
  }

  goBackToSubjects(): void {
    this.router.navigate(['/subjects']);
  }
}
