import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogActions, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'my-alert-dialog',
  templateUrl: './delete-alert-dialog.component.html',
  standalone: true,
  imports: [MatDialogActions, MatDialogModule, MatButtonModule]
})
export class DeleteDialogComponent { }