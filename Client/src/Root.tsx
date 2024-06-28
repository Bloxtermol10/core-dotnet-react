import { useSelector } from 'react-redux';
import { MessageBand } from './components/MessageBand';
import { AppStore } from './redux/store';

export function Root({ children }: { children: JSX.Element; }) {
  const messageBand = useSelector((store: AppStore) => store.messageBand)
  
  return (<>
    {messageBand.message && <MessageBand title={messageBand.title} message={messageBand.message} type={messageBand.type} />}
    {children}
  </>)
}
