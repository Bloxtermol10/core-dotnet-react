import { useEffect } from 'react';
import { userAdapter } from './adapters/user.adapter';
import { createUser } from './redux/states/user';
import { UserInfoService } from './services/User.service';
import { useDispatch } from 'react-redux';

export function Root({ children }: { children: JSX.Element; }) {
  const dispatch = useDispatch();
  const token = localStorage.getItem('token');

  async function GetUser() {
    if (token) {
      dispatch(createUser(userAdapter(await UserInfoService())));
    }
  }

  useEffect(() => {
    GetUser();
  }, [token]);

  return <>{children}</>;
}
