import { ProjectStatus } from "./enum/project-status";

export interface Project{
    id: number;
    groupId: number;
    projectNumber: number;
    name: string;
    customer: string;
    status: ProjectStatus;
    startDate: Date;
    endDate: Date;
    version: number;
    members?: number[];
}