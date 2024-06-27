import { useEffect } from 'react';
import { userAdapter } from './adapters/user.adapter';
import { createUser } from './redux/states/user';
import { UserInfoService } from './services/User.service';
import { useDispatch } from 'react-redux';
import { useSelector } from 'react-redux';
import { MessageBand } from './components/MessageBand';
import { AppStore } from './redux/store';

export function Root({ children }: { children: JSX.Element; }) {
  const messageBand = useSelector((store: AppStore) => store.messageBand)
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

  return (<>
    {messageBand.message && <MessageBand title={messageBand.title} message={messageBand.message} type={messageBand.type} />}
    {children}
  </>)
}
