import { Component } from '@angular/core';
import { SubjectService } from '../../services/subject.service';
import { SubjectDto } from '../../models/subject-dto.model';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-subject',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-subject.component.html',
  styleUrls: ['./add-subject.component.css']
})
export class AddSubjectComponent {
  subject: SubjectDto = {
    name: '',
    description: '',
    weeklyClasses: 0,
    isMandatory: false,
    credits: 0,
    literature: []
  };

  literatureInput = '';

  constructor(private subjectService: SubjectService, private router: Router) {}

  addBook(): void {
    if (this.literatureInput.trim()) {
      this.subject.literature.push(this.literatureInput.trim());
      this.literatureInput = '';
    }
  }

  submit(): void {
    this.subjectService.addSubject(this.subject).subscribe(() => {
      this.router.navigate(['/subjects']);
    });
  }
}
