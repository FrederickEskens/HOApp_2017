package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TableLayout;

import scoutsengidsenvlaanderen.be.hogids.PracticalViewPagerAdapter;
import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link MoreFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class MoreFragment extends Fragment {

    TabLayout tabLayot;
    ViewPager viewPager;

    private PracticalViewPagerAdapter viewPagerAdapter;

    public MoreFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment MoreFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static MoreFragment newInstance() {
        MoreFragment fragment = new MoreFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        viewPagerAdapter = new PracticalViewPagerAdapter(getFragmentManager());
        viewPagerAdapter.addFragment(PracticalFragment.newInstance(), "Info");
        viewPagerAdapter.addFragment(RulesFragment.newInstance(), "Leefregels");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_more, container, false);

        tabLayot = view.findViewById(R.id.tabLayout);
        viewPager = view.findViewById(R.id.viewPager);

        viewPager.setAdapter(viewPagerAdapter);
        viewPager.setOffscreenPageLimit(viewPagerAdapter.getCount());

        tabLayot.setupWithViewPager(viewPager);

        return view;
    }

}
