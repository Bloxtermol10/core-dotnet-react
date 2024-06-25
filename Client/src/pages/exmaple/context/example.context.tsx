import { ReactNode, createContext,  useContext,  useState } from "react";

export const ExampleContext = createContext('')


export function ExampleProvider({children }: {children: ReactNode}) {

    const [value, setValue] = useState('')

    return (
       <ExampleContext.Provider value={{value, setValue}}>
           {children}
       </ExampleContext.Provider>
    )
}

// eslint-disable-next-line react-refresh/only-export-components
export const useExampleContext = (): ReturnType<typeof useContext> => {
    const context = useContext(ExampleContext)
    if (context === undefined) {
        throw new Error('useExampleContext must be used within a ExampleProvider')
    }
    return context
}