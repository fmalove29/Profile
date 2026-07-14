type FooterProps = {
  name: string
}

export function Footer({ name }: FooterProps) {
  return (
    <footer className="px-6 pb-10 pt-6 text-center text-sm text-stone-500 sm:px-10 lg:px-14">
      <p>{name} Portfolio</p>
    </footer>
  )
}
