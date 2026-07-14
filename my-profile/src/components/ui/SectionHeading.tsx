type SectionHeadingProps = {
  eyebrow: string
  title: string
  description: string
}

export function SectionHeading({
  eyebrow,
  title,
  description,
}: SectionHeadingProps) {
  return (
    <header className="space-y-3">
      <p className="text-xs font-semibold uppercase tracking-[0.45em] text-stone-500">
        {eyebrow}
      </p>
      <h2 className="max-w-2xl text-3xl font-semibold tracking-tight text-stone-950 sm:text-4xl">
        {title}
      </h2>
      <p className="max-w-2xl text-base leading-7 text-stone-600">
        {description}
      </p>
    </header>
  )
}
