

export interface UserInfo { 
    id: number;
    name: string;
    email: string;
    role: string;
    routes?: UserRoutes[]
}
export interface UserRoutes { 
    id: number;
    parentId: number | null;
    name: string;
    path: string;
    visible: boolean;
}