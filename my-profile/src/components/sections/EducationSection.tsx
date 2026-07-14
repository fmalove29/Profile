import type { ProfileData } from '../../types/profile'
import { SectionHeading } from '../ui/SectionHeading'

type EducationSectionProps = {
  profile: ProfileData
}

export function EducationSection({ profile }: EducationSectionProps) {
  return (
    <section className="px-6 py-16 sm:px-10 lg:px-14">
      <div className="mx-auto max-w-7xl space-y-10">
        <SectionHeading
          eyebrow="Education"
          title="Academic background that supports practical software delivery."
          description="This section keeps your education visible without overwhelming the main professional narrative."
        />

        <div className="grid gap-6 lg:grid-cols-3">
          {profile.education.map((item) => (
            <article
              key={`${item.level}-${item.school}`}
              className="rounded-[2rem] border border-stone-200 bg-stone-950 p-8 text-stone-100 shadow-[0_22px_70px_-36px_rgba(28,25,23,0.65)]"
            >
              <p className="text-sm font-semibold uppercase tracking-[0.35em] text-stone-400">
                {item.period}
              </p>
              <h3 className="mt-5 text-2xl font-semibold">{item.level}</h3>
              <p className="mt-3 text-base leading-7 text-stone-300">{item.school}</p>
              {item.details ? (
                <p className="mt-4 text-sm leading-6 text-stone-400">
                  {item.details}
                </p>
              ) : null}
            </article>
          ))}
        </div>
      </div>
    </section>
  )
}
