import type { ProfileData } from '../../types/profile'
import { SectionHeading } from '../ui/SectionHeading'
import { Pill } from '../ui/Pill'

type ExperienceSectionProps = {
  profile: ProfileData
}

export function ExperienceSection({ profile }: ExperienceSectionProps) {
  return (
    <section className="px-6 py-16 sm:px-10 lg:px-14">
      <div className="mx-auto max-w-7xl space-y-10">
        <SectionHeading
          eyebrow="Experience"
          title="Professional work shaped by real business applications."
          description="The layout keeps the long-form storytelling feel of the reference portfolio while presenting your work history in a cleaner, résumé-friendly format."
        />

        <div className="space-y-6">
          {profile.experience.map((item) => (
            <article
              key={`${item.role}-${item.company}`}
              className="rounded-[2rem] border border-stone-200 bg-white p-8 shadow-[0_24px_70px_-34px_rgba(41,37,36,0.3)]"
            >
              <div className="grid gap-6 lg:grid-cols-[0.75fr_1.25fr]">
                <div className="space-y-4">
                  <div>
                    <p className="text-sm font-semibold uppercase tracking-[0.35em] text-stone-500">
                      {item.period}
                    </p>
                    <h3 className="mt-3 text-2xl font-semibold text-stone-950">
                      {item.role}
                    </h3>
                    <p className="mt-2 text-base text-stone-600">{item.company}</p>
                  </div>

                  <div className="flex flex-wrap gap-2">
                    {item.stack.map((tech) => (
                      <Pill key={tech}>{tech}</Pill>
                    ))}
                  </div>
                </div>

                <div className="space-y-5">
                  <p className="text-lg leading-8 text-stone-700">
                    {item.summary}
                  </p>
                  <ul className="space-y-3 text-base leading-7 text-stone-600">
                    {item.highlights.map((highlight) => (
                      <li key={highlight} className="flex gap-3">
                        <span className="mt-2 h-2.5 w-2.5 rounded-full bg-stone-900" />
                        <span>{highlight}</span>
                      </li>
                    ))}
                  </ul>
                </div>
              </div>
            </article>
          ))}
        </div>
      </div>
    </section>
  )
}
